using MedUnifyUI.Models;
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
        public async Task<IEnumerable<Patient>> getPatient()
        {
            var ValRet= await _httpClient.GetJsonAsync<Patient[]>("api/Patient");
            return ValRet;
        }
    }
}
