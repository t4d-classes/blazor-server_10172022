using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MVCServiceDemo.Models;
using MVCServiceDemo.Services.Interfaces;
using System.Diagnostics;

namespace MVCServiceDemo.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IHelloWorld _helloWorld;
    private readonly IServiceProvider _serviceProvider;

    public HomeController(
      ILogger<HomeController> logger,
      IHelloWorld helloWorld,
      IServiceProvider serviceProvider)
    {
      _logger = logger;
      _helloWorld = helloWorld; // services are injected by the container into the controller

      _serviceProvider = serviceProvider;
    }

    public IActionResult Index()
    {
      (_serviceProvider.GetService(typeof(IHelloWorld)) as IHelloWorld).SayHello();

      _helloWorld.SayHello();
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}