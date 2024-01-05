using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DAL
{
    public class Category // Определение класса Category.
    {
        public int Id { get; set; } // Уникальный идентификатор категории
        public string Name { get; set; } // Название категории
        public decimal Price { get; set; } // Цена за номер
        
    }
}
