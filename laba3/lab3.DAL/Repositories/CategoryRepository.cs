using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Этот класс является частью слоя доступа к данным (DAL - Data Access Layer) в архитектуре приложения.
// Он отвечает за взаимодействие с базой данных для объектов типа Category, предположительно представляющих категории номеров или услуг в отеле.
namespace lab3.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository //  CategorRepository определяет класс CategoryRepository, который реализует интерфейс ICategoryRepository.
    {
        private readonly HotelContext _context;  // Поле для хранения контекста базы данных.

        public CategoryRepository(HotelContext context)  // Конструктор, инициализирующий контекст базы данных. Выбрасывает исключение, если контекст не предоставлен.
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Category>> GetAllAsync() // // Асинхронный метод для получения всех категорий из базы данных.
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id) // Асинхронный метод для получения категории по её идентификатору
        {
            return await _context.Categories.FindAsync(id); // Ищет категорию по ID, используя FindAsync, который возвращает null, если категория не найдена.
        }

        public async Task AddAsync(Category category) // // Асинхронный метод для добавления новой категории в базу данных.
        {
             // Добавляет новую категорию в контекст и сохраняет изменения в базе данных.
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

         // Асинхронный метод для обновления существующей категории.
        public async Task UpdateAsync(Category category)
        {
            // Обновляет существующую категорию в контексте и сохраняет изменения.
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) // // Асинхронный метод для удаления категории по идентификатору.
        {
            var category = await _context.Categories.FindAsync(id);  // Ищет категорию по ID и удаляет её, если она найдена, затем сохраняет изменения в базе данных.
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}


/*
Асинхронность: Все методы в этом классе асинхронные, что позволяет им выполнять I/O операции без блокировки потока, улучшая производительность приложения в многопользовательских сценариях.

CRUD операции: Класс предоставляет базовые операции для работы с сущностями: создание (AddAsync), чтение (GetAllAsync и GetByIdAsync), обновление (UpdateAsync), и удаление (DeleteAsync).

Этот класс является хорошим примером репозитория, который абстрагирует логику доступа к данным от бизнес-логики приложения, делая код более чистым, поддерживаемым и удобным для тестирования
*/