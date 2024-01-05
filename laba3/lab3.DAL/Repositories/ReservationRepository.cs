using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3.DAL.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelContext _context; // Поле для хранения контекста базы данных.

        public ReservationRepository(HotelContext context) // Конструктор, инициализирующий контекст базы данных. Выбрасывает исключение, если контекст не предоставлен.
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync() // Получение всех бронирований с подробностями о комнатах
        {
            return await _context.Reservations.Include(r => r.Room).ToListAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)   // Получение бронирования по его ID с подробностями о комнате.
        {
            return await _context.Reservations
                .Include(r => r.Room)
                .SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsForRoomAsync(int roomId)  // Получение бронирований для определенной комнаты.
        {
            return await _context.Reservations
                .Include(r => r.Room)
                .Where(r => r.RoomId == roomId)
                .ToListAsync();
        }

        public async Task AddReservationAsync(Reservation reservation) // Добавление нового бронирования.
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservationAsync(Reservation reservation) // Обновление существующего бронирования.
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int id) // Удаление бронирования по его ID.
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByStatusAsync(ReservationStatus status) // Получение бронирований по статусу.
        {
            return await _context.Reservations
                .Include(r => r.Room)
                .Where(r => r.Status == status)
                .ToListAsync();
        }

        
        public async Task<Reservation> FirstOrDefaultAsync(Func<Reservation, bool> predicate) // Получение первого бронирования, удовлетворяющего заданному условию (предикату).
        {
            // Используйте AsQueryable() для преобразования DbSet в IQueryable
            return await _context.Reservations
                                 .AsQueryable() // Добавьте AsQueryable()
                                 .Where(predicate)
                                 .FirstOrDefaultAsync();
        }

    }
}


/* Интеграция с Entity Framework Core: Класс использует DbContext HotelContext.  Методы Include(r => r.Room) используются для загрузки связанных данных 
 * Асинхронность: Все методы асинхронные, что позволяет осуществлять эффективные I/O операции без блокирования потока
 Реализованы стандартные CRUD операции, а также специальные методы, такие как GetReservationsByStatusAsync и GetReservationsForRoomAsync
Предикаты для гибкости: Метод FirstOrDefaultAsync принимает предикат, позволяя вызывающему коду определить сложные условия поиска, что делает этот метод очень мощным и гибким
*/
