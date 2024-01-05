using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelBooking.Controllers
{
    public class HomeController : Controller // Добавлено для использования List
    {
        private readonly ILogger<HomeController> _logger;

        // GET: Home
        public HomeController(ILogger<HomeController> logger) 
        {
            _logger = logger; // 
        }

        public IActionResult Index()
        {
            return View();// Возвращает представление Index
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