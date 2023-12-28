using DataModel.Models;
using MedUnifyUI.Pages;
using System.Net.Http;
using System.Net.Http.Json;

namespace MedUnifyUI.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly HttpClient _httpClient;
        private bool isSuccess = false;
        private bool isError = false;
        public VisitorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7173/");
        }
        public async Task<HttpResponseMessage> AddVisitProgressNotes(ProgressNote progressNote)
        {
            var addedProgressNote = await _httpClient.PostAsJsonAsync<ProgressNote>("api/ProgressNote", progressNote);
            addedProgressNote.EnsureSuccessStatusCode();

            // Deserialize the response content to get the added patient
            var addedPatient = await addedProgressNote.Content.ReadFromJsonAsync<ProgressNote>();
            if (!addedProgressNote.IsSuccessStatusCode)
            {
         
                return addedProgressNote;
            }
            return addedProgressNote;
        }

            public async Task<Visit> AddVisit(Visit visitDto)
        {
            // Placeholder validation - Replace with actual validation logic
            if (visitDto.PatientId <= 0)
            {
            }

            // Placeholder logic to add the visit
            var addedVisit = await _httpClient.PostAsJsonAsync<Visit>("api/visit", visitDto);
            if (addedVisit.IsSuccessStatusCode)
            {
               return await addedVisit.Content.ReadFromJsonAsync<Visit>();
            }
            else
            {
                return null;
            }
        }

        public async Task<Visit> GetVisitById(int visitId)
        {
            return await _httpClient.GetFromJsonAsync<Visit>($"/api/visit/{visitId}");
        }

        public async Task<List<ProgressNote>> GetProgressNotesByVisitId(int visitId)
        {
            return await _httpClient.GetFromJsonAsync<List<ProgressNote>>($"api/visit/{visitId}/progressnotes");
        }

        public async Task<List<Visit>> GetAllVisits()
        {
            return await _httpClient.GetFromJsonAsync<List<Visit>>("/api/visit");
        }

        public async Task<List<Visit>> GetVisitsByPatientIdAsync(int patientId)
        {
            return await _httpClient.GetFromJsonAsync<List<Visit>>($"/api/visit/patient/{patientId}");
        }

      
    }
}
