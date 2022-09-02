using System.Configuration;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TournamentTracker.Data;
using TournamentTrackerWasm;
using TournamentTrackerWasm.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddSingleton<DapperRepository<Tournament>>(s => s => new DapperRepository<Tournament>(Configuration))

//Initialize database connections
TrackerLibrary.GlobalConfig.InitializeConnections(true, true);

await builder.Build().RunAsync();