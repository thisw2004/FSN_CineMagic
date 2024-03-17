using CineMagicBlazor.Components;
using CineMagicBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// builder.Services.AddHttpClient<CineMagic.Services.MovieService>(client =>
// {
//     client.BaseAddress = new Uri("http://localhost:5254/");
// });
//
// builder.Services.AddHttpClient<CineMagic.Services.RoomService>(client =>
// {
//     client.BaseAddress = new Uri("http://localhost:5254/");
// });
//
// builder.Services.AddHttpClient<CineMagic.Services.ShowService>(client =>
// {
//     client.BaseAddress = new Uri("http://localhost:5254/");
// });

builder.Services.AddScoped<CineMagic.Services.MovieService>();
builder.Services.AddScoped<CineMagic.Services.RoomService>();
builder.Services.AddScoped<CineMagic.Services.ShowService>();

builder.Services.AddHttpClient<MolliePaymentService>(molliePaymentService =>
{
    molliePaymentService.BaseAddress = new Uri("https://api.mollie.com/");
});

builder.Services.AddSingleton<MolliePaymentService>(provider => 
{
    var clientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var apiKey = "test_5gWV3vc7tT6b9Duu5T9bH6gPqSMtST"; // you need to replace this with your actual API key
    return new MolliePaymentService(clientFactory, apiKey);
});


await builder.Build().RunAsync();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();