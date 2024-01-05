using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; 


namespace HotelBooking.Controllers 
{
    public class BookingsController : Controller 
    {
        private static List<Booking> _bookings = new List<Booking>(); 

        // GET: Bookings
        public IActionResult Index() 
        {
            return View(_bookings); // Возвращает список всех бронирований
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            return View(); // Возвращает форму для создания нового бронирования
        }

        // POST: Bookings/Create
        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            try
            {
                // Добавляет новое бронирование в список
                _bookings.Add(booking); 
                return RedirectToAction("Index"); // Возвращает на страницу со списком бронирований
            }
            catch
            {
                // В случае ошибки возвращает обратно на форму создания бронирования
                return View();
            }
        }

        
    }
}


// Этот контроллер отвечает за управления бронированиями. В нем определены такие методы:
// Index - Метод Get который отображает список всех броннированийй. Он вызывается при переходе на страницу /Bookings.ОН использует переменную _bookings, которая ялвяется статическком списком для хранения данных о бронированиях.
// Данный список используется как временное хранлище данных в памяти.

//Create(Get): метод Get который отображает форму для создания нового бронирования . При переходе на страницу /Bookings/Create вызывается метод Create(Get) и отображается форма для создания нового бронирования.

// Create (Post) Метод post , который обрабатывает отправку формы создания нового бронирования. Когда форма отправляется, данные бронирования добавляются в список _bookings и происходит перенаправление на страницу /Bookings.

