using CineMagicBlazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<CineMagic.Services.MovieService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5138/");
});

builder.Services.AddHttpClient<CineMagic.Services.RoomService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5138/");
});

builder.Services.AddHttpClient<CineMagic.Services.ShowService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5138/");
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