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

            public async Task<HttpResponseMessage> AddVisitWithProgressNotes(Visit visitDto)
        {
            // Placeholder validation - Replace with actual validation logic
            if (visitDto.PatientId <= 0)
            {
                // Display an error message or handle the validation failure
                return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest };
            }

            // Placeholder logic to add the visit
            var addedVisit = await _httpClient.PostAsJsonAsync<Visit>("api/visits", visitDto);
            if (addedVisit.IsSuccessStatusCode)
            {
                // Placeholder logic to add progress notes
                foreach (var progressNote in visitDto.ProgressNotes)
                {
                    // Set the visit ID for each progress note
                    progressNote.VisitId = visitDto.Id;

                    // Call the API to add progress notes
                    var addedProgressNote = await _httpClient.PostAsJsonAsync<ProgressNote>("api/progressnotes", progressNote);
                    if (!addedProgressNote.IsSuccessStatusCode)
                    {
                        // Handle the failure to add progress notes
                        // You may choose to roll back the visit addition or handle it as needed
                        // Display an error message or log the error
                        return addedProgressNote;
                    }
                }

                return addedVisit;
            }
            else
            {
                // Handle the failure to add the visit
                // Display an error message or log the error
                return addedVisit;
            }
        }

        /* public async Task AddVisit(VisitWithProgressNotesDto newVisit)
         {
             try
             {
                 // Assuming your API endpoint for adding a visit is "/api/visits"
                 var response = await _httpClient.PostAsJsonAsync("/api/visits", newVisit);

                 // Check if the request was successful
                 response.EnsureSuccessStatusCode();
                 if (response.IsSuccessStatusCode)
                 {
                     isSuccess = true;
                     isError = false;
                     // Optionally, you can redirect or perform other actions upon success
                 }
                 else
                 {
                     isSuccess = false;
                     isError = true;
                     // Handle error, e.g., display an error message
                 }

                 // You might want to read the response content if the API returns additional data
                 // var addedVisit = await response.Content.ReadFromJsonAsync<Visit>();

                 // Note: You may choose to return the added visit if the API returns it
             }
             catch (Exception ex)
             {
                 // Log or handle the exception as needed
                 throw new ApplicationException($"Error adding visit: {ex.Message}");
             }
         }*/
    }
}
