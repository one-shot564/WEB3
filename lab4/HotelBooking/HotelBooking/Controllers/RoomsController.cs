using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; 

namespace HotelBooking.Controllers
{
    public class RoomsController : Controller
    {
        private static List<Room> _rooms = new List<Room>(); 

        // GET: Rooms
        public IActionResult Index() 
        {
            return View(_rooms); // Возвращает список всех номеров
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View(); // Возвращает форму для создания нового номера
        }

        // POST: Rooms/Create
        [HttpPost]
        public IActionResult Create(Room room) 
        {
            try
            {
                // Добавляет новый номер в список
                _rooms.Add(room);
                return RedirectToAction("Index");
            }
            catch
            {
                // В случае ошибки возвращает обратно на форму создания номера
                return View();
            }
        }

        
    }
}


/*RoomController - данный контроллер управляет номерами в отеле. В нем есть методы для просмотра и создания номеров:
 * Index - метод Get который отображает список всех номеров. Он вызывается при переходе на страницу /Rooms. Он использует переменную _rooms, которая является статическим списком для хранения данных о номерах. Данный список используется как временное хранилище данных в памяти.
 * Create(GET) метод Get который отображает форму для создания нового номера. При переходе на страницу /Rooms/Create вызывается метод Create(GET) и отображается форма для создания нового номера.
 * Create (POST): Метод POST, который обрабатывает отправку формы добавления нового номера. При успешном добавлении номера в список _rooms происходит перенаправление на метод Index, чтобы показать обновленный список номеров.
 * В обоих контроллерах используется паттерн "Post/Redirect/Get", который предотвращает повторную отправку формы при обновлении страницы пользователем после создания бронирования или номера
*/