using MedUnifyUI;
using MedUnifyUI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton<PatientService>();
builder.Services.AddSingleton<VisitorService>();
builder.Services.AddSingleton<LoginService>();
builder.Services.AddSingleton<CookieService>();
builder.Services.AddSingleton<ICookieService,CookieService>(); 

//builder.Services.AddScoped<IPatientInterface, PatientService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IPatientInterface,PatientService>(client => client.BaseAddress = new Uri("https://localhost:7173/"));
builder.Services.AddHttpClient<IVisitorService, VisitorService>(client => client.BaseAddress = new Uri("https://localhost:7173/"));
builder.Services.AddHttpClient<ILoginService,LoginService>(client => client.BaseAddress = new Uri("https://localhost:7173/"));


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7173/") });

await builder.Build().RunAsync();
