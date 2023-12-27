using DataModel.Models;

namespace MedUnifyUI.Services
{
    public interface IVisitorService
    {
        public Task<HttpResponseMessage> AddVisitWithProgressNotes(Visit visitDto);
        public Task<HttpResponseMessage> AddVisitProgressNotes(ProgressNote progressNote);
    }
}
