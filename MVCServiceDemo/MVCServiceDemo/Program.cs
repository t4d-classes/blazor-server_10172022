using MVCServiceDemo.Services;
using MVCServiceDemo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var lang = "English";

// Services is a Dependency Injection Container
// Register services with the container
if (lang == "French") {
  builder.Services.AddScoped<IHelloWorld, BonjourLeMondeConsole>();
} else {
  // Singleton: Lifetime is the entire running period of the application
  // Only one instance is ever created and used for every request
  //builder.Services.AddSingleton<IHelloWorld, HelloWorldConsole>();

  // Scoped: Lifetime is the single HTTP request/response
  // builder.Services.AddScoped<IHelloWorld, HelloWorldConsole>();

  // Transient: New service instance each time it is injected
  builder.Services.AddTransient<IHelloWorld, HelloWorldConsole>();

}

//builder.Services.AddScoped<HelloWorldConsole>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
