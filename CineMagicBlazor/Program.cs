using CineMagicBlazor.Components;
using CineMagicBlazor.Services;
using Microsoft.AspNetCore.ResponseCompression;
using System;
using Microsoft.AspNetCore.Components.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<CineMagicBlazor.Services.MovieService>(client =>
builder.Services.Configure<CircuitOptions>(options =>  // update this
{
    options.DisconnectedCircuitMaxRetained = 100;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
});

builder.Services.AddHttpClient<CineMagicBlazor.Services.MovieService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5138/");
});

builder.Services.AddHttpClient<CineMagicBlazor.Services.RoomService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5138/");
});

builder.Services.AddHttpClient<CineMagicBlazor.Services.ShowService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5254/");
});

builder.Services.AddHttpClient<MolliePaymentService>(molliePaymentService =>
{
    molliePaymentService.BaseAddress = new Uri("https://api.mollie.com/");
});

builder.Services.AddSingleton<MolliePaymentService>(provider =>
{
    var clientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var apiKey = builder.Configuration["Mollie:ApiKey"];
    var logger = provider.GetRequiredService<ILogger<MolliePaymentService>>();
    return new MolliePaymentService(clientFactory, apiKey, logger);
});

// Configure logging
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
    logging.AddEventSourceLogger();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();