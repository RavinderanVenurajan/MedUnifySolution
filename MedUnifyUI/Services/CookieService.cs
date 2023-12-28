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
        await jsRuntime.InvokeVoidAsync("Blazor.setCookie", "accessToken", value, 1);
    }

    public async Task<string> GetCookieAsync(string key)
    {
        return await jsRuntime.InvokeAsync<string>("Blazor.getCookie", key);
    }
}
