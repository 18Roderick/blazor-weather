using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using blazor_weather.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

string httpClientName = "WEATHER-API";//builder.Configuration["TodoHttpClientName"];
ArgumentException.ThrowIfNullOrEmpty(httpClientName);

builder.Services.AddHttpClient(
    httpClientName,
    client =>
    {   
        // Set the base address of the named client.
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

        // Add a user-agent default request header.
        client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
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
