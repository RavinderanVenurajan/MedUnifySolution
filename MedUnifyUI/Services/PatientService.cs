using DataModel.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MedUnifyUI.Services
{
    public class PatientService : IPatientInterface
    {
        private readonly HttpClient _httpClient;
        private readonly CookieService cookieService;
        public PatientService(HttpClient httpClient,CookieService cookie)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7173/");
             cookieService = cookie;
             SetJwtToken();
        }
        public async Task<List<Patient>> getPatient()
        {
            //string token = await cookieService.GetCookieAsync("accessToken");
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var ValRet= await _httpClient.GetFromJsonAsync<List<Patient>>("api/Patient");
            return ValRet;
        }
        private async void SetJwtToken()
        {
          //  string token = await cookieService.GetCookieAsync("accessToken");
           // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<Patient> AddPatient(Patient newPatient)
        {
            try
            {


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

        public async Task DeletePatient(int patientId)
        {
            await _httpClient.DeleteAsync($"/api/patient/{patientId}");
        }

        public async Task UpdatePatient(int patientId, Patient updatedPatient)
        {
            await _httpClient.PutAsJsonAsync($"/api/patient/{patientId}", updatedPatient);
        }
        public async Task<Patient> GetPatientById(int patientId)
        {
            return await _httpClient.GetFromJsonAsync<Patient>($"/api/patient/{patientId}");
        }
    }
}
