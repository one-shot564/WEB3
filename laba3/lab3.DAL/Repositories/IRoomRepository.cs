using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab3.DAL.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync(); // Асинхронно извлекает коллекцию всех комнат.
        Task<Room> GetRoomByIdAsync(int roomId); // Асинхронно извлекает конкретную комнату по ее уникальному идентификатору.
        Task<IEnumerable<Room>> GetRoomsByCategoryAsync(int categoryId); // Асинхронно извлекает коллекцию комнат, относящихся к определенной категории.
        Task AddRoomAsync(Room room); // Асинхронно добавляет новую комнату в хранилище (и, предположительно, в базовую базу данных).
        Task UpdateRoomAsync(Room room); // Асинхронно обновляет информацию о существующей комнате в хранилище.
        Task DeleteRoomAsync(int roomId); // Асинхронно удаляет комнату из хранилища на основе ее идентификатора.

    }


}

/*
 * Асинхронные операции: Все методы возвращают Task или Task<T>, указывая на то, что они предназначены для асинхронного выполнения
 * Операции CRUD: Интерфейс определяет методы для типичных операций CRUD:

Создать: AddRoomAsync для добавления новых записей о номерах.
Читать: GetAllRoomsAsync, GetRoomByIdAsync и GetRoomsByCategoryAsync для получения записей о комнатах.
Обновить: UpdateRoomAsync для изменения существующей комнаты.
Удалить: DeleteRoomAsync для удаления записи о комнате.
*/