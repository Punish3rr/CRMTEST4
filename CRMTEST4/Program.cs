//using CRMTEST4;
//using CRMTEST4.Models;
//using CRMTEST4.Pages;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

//var builder = WebAssemblyHostBuilder.CreateDefault(args);
///*builder.RootComponents.Add<App>("#app")*/;
//builder.RootComponents.Add<Login>("#app");


//builder.RootComponents.Add<App>("#app");


//builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped<IAuthService, AuthService>();
//await builder.Build().RunAsync();


//using CRMTEST4;
//using CRMTEST4.Models;
//using CRMTEST4.Pages;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

//var builder = WebAssemblyHostBuilder.CreateDefault(args);

//// Set up authentication service
//builder.Services.AddScoped<IAuthService, AuthService>();

//// Add the Login component as the root component
//builder.RootComponents.Add<Login>("app");

//// Add the HeadOutlet component for the <head> section
//builder.RootComponents.Add<HeadOutlet>("head::after");

//// Build the app
//var app = builder.Build();

//// Get an instance of the authentication service
//var authService = app.Services.GetRequiredService<IAuthService>();

//// Check if the user is already authenticated
//if (await authService.AuthenticatedAsync())
//{
//    // If the user is authenticated, navigate to the App component
//    var navigationManager = app.Services.GetRequiredService<NavigationManager>();
//    navigationManager.NavigateTo("app");
//}
//else
//{
//    // If the user is not authenticated, start the app
//    await app.RunAsync();
//}

using CRMTEST4;
using CRMTEST4.Models;
using CRMTEST4.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register the HttpClient service
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Set up authentication service
builder.Services.AddScoped<IAuthService, AuthService>();

// Add the Login component as the root component
builder.RootComponents.Add<Login>("#app");

// Add the HeadOutlet component for the <head> section
builder.RootComponents.Add<HeadOutlet>("head::after");

// Build the app
var appp = builder.Build();

// Get an instance of the authentication service
var authService = appp.Services.GetRequiredService<IAuthService>();

// Check if the user is already authenticated
if (await authService.AuthenticatedAsync())
{
    // If the user is authenticated, navigate to the App component
    var navigationManager = appp.Services.GetRequiredService<NavigationManager>();
    navigationManager.NavigateTo("/home");
 
}
else if (!await authService.AuthenticatedAsync())
{
    // If the user is not authenticated, start the app
    var navigationManager = appp.Services.GetRequiredService<NavigationManager>();
    navigationManager.NavigateTo("/login");
    await builder.Build().RunAsync();

}
