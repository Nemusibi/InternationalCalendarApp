using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using CalendarClient;
using CalendarClient.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CalendarClient.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<CalendarClient.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7088/") });

// Register Services
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<CalendarService>();


builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
