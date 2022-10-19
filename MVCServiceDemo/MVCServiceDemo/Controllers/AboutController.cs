using Microsoft.AspNetCore.Mvc;

namespace MVCServiceDemo.Controllers
{
  public class AboutController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
