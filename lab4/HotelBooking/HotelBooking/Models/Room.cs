namespace HotelBooking.Models
{
    public class Room
    {
        public int Id { get; set; } // модель для номера
        public string Category { get; set; } // категория
        public double Price { get; set; } // цена
        public bool IsAvailable { get; set; } // доступность
    }

}
