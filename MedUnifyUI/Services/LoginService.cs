using DataModel.Models;
using System.Net.Http;
using System.Net.Http.Json;



namespace MedUnifyUI.Services
{
    public class LoginService: ILoginService
    {
        private readonly HttpClient _httpClient;
        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7173/");
        }
        public async Task<string> LoginAsync(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResult>();
              //  await localStorage.SetItemAsync("accessToken", result.Token);
                return result.Token;
            }

            // Handle login failure here if needed
            return null;
        }
    }
}
