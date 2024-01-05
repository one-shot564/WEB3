using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; // Добавлено для использования List<>
using System.Linq; // Добавлено для использования LINQ
using lab6.Models;


namespace lab6.Controllers
{
    public class BookingController : Controller
    {
        // Заглушка для списка номеров
        private static List<Room> availableRooms = new List<Room>
        {
            //  начальные данные о комнатах
            new Room { Id = 1, Number = "101", Type = "Одиночный", Price = 50.00 },
            new Room { Id = 2, Number = "102", Type = "Двойной", Price = 75.00 },
            new Room { Id = 3, Number = "103", Type = "Одиночный", Price = 55.00 },
            new Room { Id = 4, Number = "104", Type = "Двойной", Price = 80.00 },
        };

        // Заглушка для списка бронирований
        private static List<Booking> bookings = new List<Booking>();
        private static int nextBookingId = 1; // Идентификатор для следующего бронирования

        public IActionResult Index()
        {
            // Возвращаем представление со списком доступных номеров
            return View(availableRooms);
        }

        [HttpGet]
        public IActionResult GetAvailableRooms(string type, double? minPrice, double? maxPrice)
        {
            // Фильтруем список доступных номеров по типу и диапазону цен
            var filteredRooms = availableRooms.AsQueryable();

            if (!string.IsNullOrWhiteSpace(type))
            {
                filteredRooms = filteredRooms.Where(r => r.Type == type);
            }
            if (minPrice.HasValue)
            {
                filteredRooms = filteredRooms.Where(r => r.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                filteredRooms = filteredRooms.Where(r => r.Price <= maxPrice.Value);
            }

            return Json(filteredRooms.ToList());
        }

        [HttpPost]
        public IActionResult BookRoom(int roomId)
        {
            // Проверяем, доступен ли номер
            var room = availableRooms.FirstOrDefault(r => r.Id == roomId);
            if (room == null)
            {
                return NotFound("Номер не найден.");
            }

            // Создаем бронирование и добавляем его в список
            var booking = new Booking { Id = nextBookingId++, RoomId = roomId };
            bookings.Add(booking);

            

            return Ok(new { Message = "Номер забронирован успешно.", BookingId = booking.Id });
        }

        [HttpPost]
        public IActionResult CancelBooking(int bookingId)
        {
            // Находим бронирование и удаляем его
            var booking = bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null)
            {
                return NotFound("Бронирование не найдено.");
            }

            bookings.Remove(booking);

           

            return Ok("Бронирование успешно отменено.");
        }
    }
}

