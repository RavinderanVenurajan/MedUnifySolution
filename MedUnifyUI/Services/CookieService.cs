// CookieService.cs

using Microsoft.JSInterop;
using System.Threading.Tasks;

public interface ICookieService
{
    Task SetCookieAsync(string value);
    Task<string> GetCookieAsync(string key);
}

public class CookieService : ICookieService
{
    private readonly IJSRuntime jsRuntime;

    public CookieService(IJSRuntime jsRuntime)
    {
        this.jsRuntime = jsRuntime;
    }

    public async Task SetCookieAsync(string value)
    {
        // await jsRuntime.InvokeVoidAsync("Blazor.setCookie", "accessToken", value, 1);
        // await jsRuntime.InvokeVoidAsync("localStorage.setItem", "accessToken", value);
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "accessToken", value);
        Console.WriteLine("Retrieved Token: " + value);
    }

    public async Task<string> GetCookieAsync(string key)
    {
        // return await jsRuntime.InvokeAsync<string>("Blazor.getCookie", key);
       // var storedToken = jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "jwtToken");
        //  return await jsRuntime.InvokeAsync<string>("localStorage.getItem", "key");
        return await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "accessToken"); ;
    }
}
