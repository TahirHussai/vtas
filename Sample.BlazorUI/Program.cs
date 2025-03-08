using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using Sample.BlazorUI.AuthProvider;
using Sample.BlazorUI.Data;
using Sample.BlazorUI.Repository.Implementation;
using Sample.BlazorUI.Repository.Interface;
using Sample.BlazorUI.Services.Implementation;
using Sample.BlazorUI.Services.Interface;
using Sample.Services.Implementations;
using System.IdentityModel.Tokens.Jwt;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<ILookUpRepository, LookUpRepository>();
builder.Services.AddTransient<IRegionService, Sample.BlazorUI.Services.Implementation.RegionService>();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddSingleton<LoaderService>();
builder.Services.AddScoped<AuthenticationProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p =>
p.GetRequiredService<AuthenticationProvider>());
builder.Services.AddScoped<JwtSecurityTokenHandler>();
builder.Services.AddHttpClient("LocalApi", client => client.BaseAddress = new Uri("https://localhost:7182"));
builder.Services.AddServerSideBlazor()
       .AddCircuitOptions(options => {
           options.DetailedErrors = true;
           options.DisconnectedCircuitMaxRetained = 100; // Allow reconnection
           options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(5);
       })
       .AddHubOptions(options =>
        {
            options.ClientTimeoutInterval = TimeSpan.FromSeconds(60); // Increase timeout
            options.HandshakeTimeout = TimeSpan.FromSeconds(30); // Optional
            options.KeepAliveInterval = TimeSpan.FromSeconds(15); // Keep the connection alive
        });

builder.Services.AddSignalR(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
    options.KeepAliveInterval = TimeSpan.FromSeconds(30);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
