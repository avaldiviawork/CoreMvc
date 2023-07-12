using CoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //This is a method in a controller class in an ASP.NET Core MVC application. It is used to return a view to the user. The view is usually a web page that is rendered
        // in the browser. The Index() method is typically used to return the main page of the application.
        public IActionResult Index()
        {
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