using DataModel.Models;
using MedUnifyApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class VisitController : ControllerBase
{
    private readonly MedUnifyContext _context;

    public VisitController(MedUnifyContext context)
    {
        _context = context;
    }

    // GET: api/visit
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Visit>>> GetVisits()
    {
        return await _context.Visits.ToListAsync();
    }

    // GET: api/visit/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Visit>> GetVisit(int id)
    {
        var visit = await _context.Visits.FindAsync(id);

        if (visit == null)
        {
            return NotFound();
        }

        return visit;
    }
    
    // GET: api/visit/{visitId}/progressnotes
    [HttpGet("{visitId}/progressnotes")]
    public async Task<ActionResult<IEnumerable<ProgressNote>>> GetProgressNotesByVisitId(int visitId)
    {
        var visit = await _context.Visits.FindAsync(visitId);

        if (visit == null)
        {
            return NotFound();
        }

        var progressNotes = await _context.ProgressNotes
            .Where(p => p.VisitId == visitId)
            .ToListAsync();

        return progressNotes;
    }

    // POST: api/visit
    [HttpPost]
    public async Task<ActionResult<Visit>> PostVisit(Visit visit)
    {
        _context.Visits.Add(visit);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVisit), new { id = visit.Id }, visit);
    }

    // PUT: api/visit/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVisit(int id, Visit visit)
    {
        if (id != visit.Id)
        {
            return BadRequest();
        }

        _context.Entry(visit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VisitExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/visit/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVisit(int id)
    {
        var visit = await _context.Visits.FindAsync(id);
        if (visit == null)
        {
            return NotFound();
        }

        _context.Visits.Remove(visit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // GET: api/visit/patient/{patientId}
    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<IEnumerable<Visit>>> GetVisitsByPatientId(int patientId)
    {
        var visits = await _context.Visits
            .Where(v => v.PatientId == patientId)
            .ToListAsync();

        if (visits == null || visits.Count == 0)
        {
            return NotFound($"No visits found for patient with ID {patientId}");
        }

        return visits;
    }

    private bool VisitExists(int id)
    {
        return _context.Visits.Any(e => e.Id == id);
    }
}
