using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab3.DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _context; // Поле для хранения контекста базы данных.

        public RoomRepository(HotelContext context) // Конструктор, инициализирующий контекст базы данных. Выбрасывает исключение, если контекст равен null.
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync() // Получает все комнаты вместе с их ассоциированной категорией.
        {
            return await _context.Rooms.Include(r => r.Category).ToListAsync();
        }

        
        public async Task<Room> GetRoomByIdAsync(int id) // Получает конкретную комнату по ее идентификатору и категории.
        {
            return await _context.Rooms.Include(r => r.Category).SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Room>> GetRoomsByCategoryAsync(int categoryId) // Получает все комнаты, относящиеся к определенной категории.
        {
            return await _context.Rooms
                .Include(r => r.Category)
                .Where(r => r.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task AddRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(Room room) // Обновление информации о существующей комнате в базе данных.
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int id) // Удаляет комнату из базы данных по ее идентификатору.
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }

        
    }
}

/*
 * Асинхронные операции: Все методы являются асинхронными (Task или Task<T>), что позволяет выполнять неблокирующие вызовы базы данных.
 * Операции CRUD: Хранилище реализует стандартные операции Create, Read, Update и Delete:

Создать: AddRoomAsync для добавления новых комнат.
Чтение: GetAllRoomsAsync, GetRoomByIdAsync и GetRoomsByCategoryAsync для получения номеров.
Обновить: UpdateRoomAsync для изменения существующих комнат.
Удалить: DeleteRoomAsync для удаления номеров.
*/