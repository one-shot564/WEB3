using Microsoft.AspNetCore.Mvc;
using laba5.Models; 
using System.Collections.Generic; 

namespace laba5.Controllers
{
    [ApiController] // Указывает, что этот контроллер обрабатывает запросы API
    [Route("[controller]")] // Маршрут к контроллеру
    public class ReservationsController : ControllerBase // Контроллер для работы с бронированиями
    {
        private static List<Reservation> reservations = new List<Reservation>(); // Это временное хранилище, позже можно заменить на базу данных

        // Получение всех бронирований
        [HttpGet]
        public IActionResult GetAll()// Возвращает все бронирования
        {
            return Ok(reservations); // Возвращает код 200 OK и список бронирований
        }

        // Получение одного бронирования по ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Возвращает одно бронирование по его ID
        {
            var reservation = reservations.Find(r => r.Id == id);// Поиск бронирования по ID
            if (reservation == null)// Если бронирование не найдено
            {
                return NotFound();// Возвращает код 404 Not Found
            }
            return Ok(reservation);// Возвращает код 200 OK и бронирование
        }

        // Создание нового бронирования
        [HttpPost]
        public IActionResult Create([FromBody] Reservation reservation)// Создаёт новое бронирование
        {
            reservations.Add(reservation);// Добавляет бронирование в список
            return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);// Возвращает код 201 Created и созданное бронирование
        }

        // Обновление бронирования
        [HttpPut("{id}")]// Обновляет бронирование по его ID
        public IActionResult Update(int id, [FromBody] Reservation reservation)// Обновляет бронирование
        {
            var index = reservations.FindIndex(r => r.Id == id);// Поиск бронирования по ID
            if (index == -1)// Если бронирование не найдено
            {
                return NotFound();// Возвращает код 404 Not Found
            }
            reservations[index] = reservation;// Обновляет бронирование
            return NoContent();// Возвращает код 204 No Content
        }

        // Удаление бронирования
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)// Удаляет бронирование по его ID
        {
            var index = reservations.FindIndex(r => r.Id == id);// Поиск бронирования по ID
            if (index == -1)// Если бронирование не найдено
            {
                return NotFound();// Возвращает код 404 Not Found
            }
            reservations.RemoveAt(index);// Удаляет бронирование
            return NoContent();// Возвращает код 204 No Content
        }
    }
}
