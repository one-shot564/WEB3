using System;
using System.Threading.Tasks;
using lab3.DAL; // Убедитесь, что пространство имен для IUnitOfWork верное

namespace lab3.BLL
{
    public class BookingManager
    {
        // Поле для хранения ссылки на объект, реализующий интерфейс IUnitOfWork.
        private readonly IUnitOfWork _unitOfWork;

        // Конструктор класса, принимающий объект, реализующий интерфейс IUnitOfWork.
        // Это позволяет инжектировать зависимость и использовать различные реализации в разное время (например, при тестировании).
        public BookingManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

         // Асинхронный метод, который проверяет, доступен ли номер (roomId) для бронирования на заданный период (checkIn - checkOut).
        public async Task<bool> IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            // // Используется лямбда-выражение для определения условий, при которых номер считается занятым.
            var existingReservation = await _unitOfWork.Reservations
                .FirstOrDefaultAsync(r => r.RoomId == roomId && r.CheckIn < checkOut && r.CheckOut > checkIn);
            // // Возвращает true, если пересекающихся бронирований не найдено, т.е. номер доступен.
            return existingReservation == null; 
        }

        
    }
}
