using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DAL
{
    // Определение класса Room.
    public class Room
    {
        public int Id { get; set; } // Уникальный идентификатор комнаты
        public string Number { get; set; } // Номер комнаты
        public int CategoryId { get; set; } // Ссылка на категорию
        public Category Category { get; set; } // Навигационное свойство
        // 
    }
}

