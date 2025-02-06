using Blazored.LocalStorage;
using LotteryManager.UI;
using LotteryManager.UI.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        // Add services to the container.
        builder.Services.AddBlazoredLocalStorage();

        builder.Services.AddAuthorizationCore();
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


        //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https+http://localhost:5043") });
        builder.Services.AddHttpClient<ApiClient>(client =>
        {
            // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
            // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
            client.BaseAddress = new("http://localhost:5043");
        });

        await builder.Build().RunAsync();
    }
}