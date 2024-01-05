namespace laba5.Models
{
    public class Reservation// Модель бронирования
    {
        public int Id { get; set; }// ID бронирования
        public int RoomId { get; set; }// ID номера
        public int CustomerId { get; set; }// ID клиента
        public DateTime CheckInDate { get; set; }// Дата заезда
        public DateTime CheckOutDate { get; set; }// Дата выезда
        
    }
}
