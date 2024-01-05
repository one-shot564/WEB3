namespace HotelBooking.Models
{
    public class Booking 
    {
        public int Id { get; set; } // модель для бронирования
        public int RoomId { get; set; }// номер комнаты
        public DateTime StartDate { get; set; } // дата начала
        public DateTime EndDate { get; set; } // дата окончания
    }
}
