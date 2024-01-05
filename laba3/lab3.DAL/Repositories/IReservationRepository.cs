using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DAL.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservationsByStatusAsync(ReservationStatus status);//  Получение списка бронирований по статусу (например, подтвержденные, ожидающие и т.д.).
        Task<Reservation> GetReservationByIdAsync(int reservationId); // Получение бронирования по его уникальному идентификатору.
        Task<IEnumerable<Reservation>> GetReservationsForRoomAsync(int roomId);  // Получение списка всех бронирований для конкретной комнаты.
        Task AddReservationAsync(Reservation reservation); // Добавление нового бронирования.
        Task UpdateReservationAsync(Reservation reservation);  // Обновление существующего бронирования.
        Task DeleteReservationAsync(int reservationId); // Удаление бронирования по его идентификатору.


        Task<Reservation> FirstOrDefaultAsync(Func<Reservation, bool> predicate); // Метод для получения первого бронирования, удовлетворяющего заданному условию (предикату).
    }


}


/*Асинхронность: Все методы возвращают Task или Task<T>, что указывает на то, что они предназначены для асинхронного выполнения
 * CRUD операции и более: Интерфейс определяет методы для стандартных операций CRUD, а также специализированные методы для работы с бронированиями, такие как получение бронирований по статусу или комнате.
 * Гибкость: Метод FirstOrDefaultAsync представляет собой пример  метода, который позволяет вызывающему коду определить условие (предикат) для поиска бронирований
*/