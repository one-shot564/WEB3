using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace lab3.DAL
{
    // Определение перечисления для статуса бронирования
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }

    public class Reservation // Определение класса Reservation.
    {
        public int Id { get; set; } // Уникальный идентификатор бронирования
        public int RoomId { get; set; } // Ссылка на комнату
        public Room Room { get; set; } // Навигационное свойство
        public DateTime CheckIn { get; set; } //
        public DateTime CheckOut { get; set; }
        public string CustomerName { get; set; } // Имя клиента
        public bool IsConfirmed { get; set; } // Подтверждено ли бронирование

        // Добавляем свойство Status с типом ReservationStatus
        public ReservationStatus Status { get; set; }

        
    }
}
