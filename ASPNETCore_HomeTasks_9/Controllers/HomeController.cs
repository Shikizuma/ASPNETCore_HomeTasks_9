using ASPNETCore_HomeTasks_9.Infrastructure;
using ASPNETCore_HomeTasks_9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETCore_HomeTasks_9.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [TypeFilter(typeof(UniqueUserFilter))]
        public IActionResult Index()
        {
            return View();
        }
        [TypeFilter(typeof(UniqueUserFilter))]
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