using MedUnifyApi.Data;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedUnifyApi.Controllers
{
    // Controllers/ProgressNoteController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressNoteController : ControllerBase
    {
        private readonly MedUnifyContext _context;

        public ProgressNoteController(MedUnifyContext context)
        {
            _context = context;
        }

        // GET: api/ProgressNote
        [HttpGet]
        public IActionResult GetProgressNotes()
        {
            var progressNotes = _context.ProgressNotes.ToList();
            return Ok(progressNotes);
        }

        // GET: api/ProgressNote/5
        [HttpGet("{id}")]
        public IActionResult GetProgressNote(int id)
        {
            var progressNote = _context.ProgressNotes.Find(id);

            if (progressNote == null)
            {
                return NotFound();
            }

            return Ok(progressNote);
        }

        // POST: api/ProgressNote
        [HttpPost]
        public IActionResult CreateProgressNote([FromBody] ProgressNote progressNote)
        {
            if (progressNote == null)
            {
                return BadRequest();
            }

            _context.ProgressNotes.Add(progressNote);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProgressNote), new { id = progressNote.Id }, progressNote);
        }

        // PUT: api/ProgressNote/5
        [HttpPut("{id}")]
        public IActionResult UpdateProgressNote(int id, [FromBody] ProgressNote updatedProgressNote)
        {
            var progressNote = _context.ProgressNotes.Find(id);

            if (progressNote == null)
            {
                return NotFound();
            }

            progressNote.SectionName = updatedProgressNote.SectionName;
            progressNote.SectionText = updatedProgressNote.SectionText;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ProgressNote/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProgressNote(int id)
        {
            var progressNote = _context.ProgressNotes.Find(id);

            if (progressNote == null)
            {
                return NotFound();
            }

            _context.ProgressNotes.Remove(progressNote);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
