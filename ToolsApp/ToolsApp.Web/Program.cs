using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Microsoft.EntityFrameworkCore;

using ToolsApp.Core.Interfaces.Data;
using ToolsApp.Data;
using ToolsApp.Web.Data;
using ToolsApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);


// Scoped Service
//builder.Services.AddDbContext<ToolsAppDbContext>(options => {
//  options.UseSqlServer(builder.Configuration["ConnectionString"]);
//});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<ScreenBlocker>();

builder.Services.AddSingleton<ToolsAppDapperContext>();

if (builder.Configuration["ConnectionString"] == "in-memory")
{
  //builder.Services.AddSingleton<IColorsData, ColorsInMemoryData>();
  //builder.Services.AddSingleton<ICarsData, CarsInMemoryData>();
}
else
{
  //builder.Services.AddScoped<IColorsData, ColorsSqlDatabaseData>();
  //builder.Services.AddScoped<ICarsData, CarsSqlDatabaseData>();
  builder.Services.AddSingleton<IColorsData, ColorsDapperData>();
  builder.Services.AddSingleton<ICarsData, CarsDapperData>();
}








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
