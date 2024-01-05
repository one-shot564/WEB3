namespace laba5.Models
{
    public class Room// Модель номера
    {
        public int Id { get; set; }// ID номера
        public string Category { get; set; }// Категория номера
        public decimal Price { get; set; }// Цена номера
        public bool IsAvailable { get; set; }// Доступность номера
    }
}
