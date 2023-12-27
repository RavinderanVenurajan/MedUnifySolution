using DataModel.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MedUnifyUI.Services
{
    public class PatientService : IPatientInterface
    {
        private readonly HttpClient _httpClient;
        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7173/");
        }
        public async Task<List<Patient>> getPatient()
        {
            var ValRet= await _httpClient.GetFromJsonAsync<List<Patient>>("api/Patient");
            return ValRet;
        }
        public async Task<Patient> AddPatient(Patient newPatient)
        {
            try
            {
                // Assuming your API endpoint for adding a patient is "/api/patients"
                var response = await _httpClient.PostAsJsonAsync("/api/patient", newPatient);

                // Check if the request was successful
                response.EnsureSuccessStatusCode();

                // Deserialize the response content to get the added patient
                var addedPatient = await response.Content.ReadFromJsonAsync<Patient>();

                return addedPatient;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new ApplicationException($"Error adding patient: {ex.Message}");
            }
        }
    }
}
