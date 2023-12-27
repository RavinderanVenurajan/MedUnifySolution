using DataModel.Models;
using MedUnifyApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class VisitsController : ControllerBase
{
    private readonly MedUnifyContext _dbContext;

    public VisitsController(MedUnifyContext dbContext)
    {
        _dbContext = dbContext;
    }
 

    [HttpPost]
    public async Task<ActionResult<Visit>> AddVisitWithProgressNotes([FromBody] Visit visitDto)
    {
        // Validate the input as needed

        var visit = new Visit
        {
            PatientId = visitDto.PatientId,
            VisitDate = visitDto.VisitDate,
        };

        _dbContext.Visits.Add(visit);
        await _dbContext.SaveChangesAsync();

        var progressNotes = visitDto.ProgressNotes
            .Select(noteDto => new ProgressNote
            {
                VisitId = visit.Id,
                SectionName = noteDto.SectionName,
                SectionText = noteDto.SectionText,
            })
            .ToList();

        _dbContext.ProgressNotes.AddRange(progressNotes);
        await _dbContext.SaveChangesAsync();

        // You can return the visit if needed
        return CreatedAtAction(nameof(GetVisitById), new { id = visit.Id }, visit);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Visit>> GetVisitById(int id)
    {
        Visit visits = new Visit();
     

        var visit = await _dbContext.Visits.FindAsync(id);
       
        if (visit == null)
        {
            return NotFound();
        }
        var progressNotes = _dbContext.ProgressNotes
           .Where(note => note.VisitId == id)
           .ToList();
        visit.ProgressNotes = progressNotes;
        //foreach (var notes in progressNotes)
        //{
        //    visit.ProgressNotes.Add(notes);
        //}
        return Ok(visit);
    }
}
