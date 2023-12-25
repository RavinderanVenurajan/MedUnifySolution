using MedUnifyApi.Data;
using MedUnifyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MedUnifyApi.Service
{
    // ProgressNotesService.cs
    public class ProgressNotesService
    {
        private readonly MedUnifyContext _context;

        public ProgressNotesService(MedUnifyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgressNote>> GetProgressNotesByVisitIdAsync(int visitId)
        {
            return await _context.ProgressNotes.Where(p => p.VisitId == visitId).ToListAsync();
        }

        public async Task<int> AddProgressNotesAsync(IEnumerable<ProgressNote> progressNotes)
        {
            _context.ProgressNotes.AddRange(progressNotes);
            await _context.SaveChangesAsync();
            return progressNotes.First().VisitId;
        }

        public async Task<bool> UpdateProgressNoteAsync(int noteId, ProgressNote updatedNote)
        {
            var existingNote = await _context.ProgressNotes.FindAsync(noteId);

            if (existingNote == null)
            {
                return false;
            }

            existingNote.SectionName = updatedNote.SectionName;
            existingNote.SectionText = updatedNote.SectionText;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProgressNoteAsync(int noteId)
        {
            var note = await _context.ProgressNotes.FindAsync(noteId);

            if (note == null)
            {
                return false;
            }

            _context.ProgressNotes.Remove(note);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ProgressNote> GetProgressNoteByIdAsync(int noteId)
        {
            return await _context.ProgressNotes.FindAsync(noteId);
        }
    }

}
