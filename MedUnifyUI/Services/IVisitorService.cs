using DataModel.Models;
using System.Net.Http;

namespace MedUnifyUI.Services
{
    public interface IVisitorService
    {
        public Task<Visit> AddVisit(Visit visitDto);
        public Task<HttpResponseMessage> AddVisitProgressNotes(ProgressNote progressNote);
        public Task<Visit> GetVisitById(int visitId);
        public Task<List<ProgressNote>> GetProgressNotesByVisitId(int visitId);
        public Task<List<Visit>> GetAllVisits();
        public Task<List<Visit>> GetVisitsByPatientIdAsync(int patientId);
    }
}
