using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Sample.BlazorServer.Implementation;
using Sample.BlazorServerAPP.AuthProvider;
using Sample.BlazorServerAPP.ExternaServices.Data;
using Sample.BlazorServerAPP.Implementation;
using Sample.BlazorServerAPP.Middleware;
using Sample.BlazorServerAPP.Service;
using Stripe;
using System.IdentityModel.Tokens.Jwt;
using Toolbelt.Blazor.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
//builder.Services.AddTransient<IOpenAIHelperService, OpenAIHelperService>();
builder.Services.AddScoped<RefreshTokenService>();
builder.Services.AddScoped<HttpInterceptorService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddTransient<IUpload, Upload>();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p =>
p.GetRequiredService<AuthenticationProvider>());
builder.Services.AddScoped<JwtSecurityTokenHandler>();


builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();



StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe")["ApiKey"];

builder.Services.AddScoped(sp =>
{
    var baseUrl = "https://localhost:7182/"; //builder.Configuration["AppSettings:BaseUrl"];
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri(baseUrl)
    };
    return httpClient;
});

builder.Services.AddHttpClientInterceptor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// enable Web Sockets
app.UseWebSockets();

// attach the Text Control WebSocketHandler middleware
//app.UseTXWebSocketMiddleware();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();