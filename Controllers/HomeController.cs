using DataBaseCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataBaseCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDBContext;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentDBContext studentDBContext)
        {
            //initialize DB
            this.studentDBContext = studentDBContext;
        }

        public IActionResult Index()
        {
            var stdData = studentDBContext.Students.ToList();
            return View(stdData);
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
