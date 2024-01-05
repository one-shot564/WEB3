using Microsoft.AspNetCore.Mvc;
using laba5.Models;
using System.Collections.Generic;
using System.Linq;

namespace laba5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private static List<Room> rooms = new List<Room>();

        // Статический конструктор для инициализации начальных данных
        static RoomsController()
        {
            rooms = new List<Room>
            {
                new Room { Id = 1, Category = "Economy", Price = 50.00m, IsAvailable = true },// Инициализирует начальные данные
                new Room { Id = 2, Category = "Economy", Price = 50.00m, IsAvailable = false },// Инициализирует начальные данные
                new Room { Id = 3, Category = "Deluxe", Price = 120.00m, IsAvailable = true },// Инициализирует начальные данные
                new Room { Id = 4, Category = "Deluxe", Price = 120.00m, IsAvailable = false },// Инициализирует начальные данные
                // Добавь ещё комнаты при необходимости
            };
        }

        // Получение всех номеров
        [HttpGet]
        public IActionResult GetAllRooms()// Возвращает все номера
        {
            return Ok(rooms);// Возвращает код 200 OK и список всех номеров
        }

        // Получение доступных номеров
        [HttpGet("available")]
        public IActionResult GetAvailableRooms()// Возвращает доступные номера
        {
            var availableRooms = rooms.Where(r => r.IsAvailable).ToList();// Получает доступные номера
            return Ok(availableRooms);// Возвращает код 200 OK и список доступных номеров
        }

        // Получение информации о конкретном номере по ID
        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            var room = rooms.FirstOrDefault(r => r.Id == id);// Поиск бронирования по ID
            if (room == null)// Если бронирование не найдено
            {
                return NotFound();// Возвращает код 404 Not Found
            }
            return Ok(room);// Возвращает код 200 OK и бронирование
        }

        // Создание нового номера
        [HttpPost]
        public IActionResult CreateRoom([FromBody] Room room)// Создаёт новый номер
        {
            // Установка ID новой комнаты
            room.Id = rooms.Any() ? rooms.Max(r => r.Id) + 1 : 1;// Устанавливает ID новой комнаты
            rooms.Add(room);// Добавляет новый номер в список
            return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);// Возвращает код 201 Created и созданный номер
        }

        // Обновление информации о номере
        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, [FromBody] Room updatedRoom)// Обновляет бронирование
        {
            var roomIndex = rooms.FindIndex(r => r.Id == id);// Поиск бронирования по ID
            if (roomIndex == -1)// Если бронирование не найдено
            {
                return NotFound();// Возвращает код 404 Not Found
            }

            // Обновление данных комнаты
            rooms[roomIndex] = updatedRoom;// Обновляет бронирование
            return NoContent();// Возвращает код 204 No Content
        }

        // Удаление номера
        [HttpDelete("{id}")]// Удаляет бронирование по его ID
        public IActionResult DeleteRoom(int id)// Удаляет бронирование по его ID
        {
            var roomIndex = rooms.FindIndex(r => r.Id == id);// Поиск бронирования по ID
            if (roomIndex == -1)// Если бронирование не найдено
            {
                return NotFound();// Возвращает код 404 Not Found
            }

            rooms.RemoveAt(roomIndex);// Удаляет бронирование
            return NoContent();// Возвращает код 204 No Content
        }
    }
}
