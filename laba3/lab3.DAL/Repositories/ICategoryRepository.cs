using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DAL.Repositories
{
    public interface ICategoryRepository  // Определение интерфейса ICategoryRepository.
    {
        Task<IEnumerable<Category>> GetAllAsync();// Метод для получения всех категорий. Возвращает коллекцию категорий.
        Task<Category> GetByIdAsync(int id); // Метод для получения одной категории по её идентификатору. Возвращает одну категорию или null.
        Task AddAsync(Category category);  // Метод для добавления новой категории в репозиторий (и, следовательно, в базу данных).
        Task UpdateAsync(Category category); // Метод для обновления существующей категории.
        Task DeleteAsync(int id); // Метод для удаления категории по её идентификатору.
    }

}

/*CRUD операции: Интерфейс определяет стандартный набор операций CRUD для Category:

Create (создание) представлено методом AddAsync.
Read (чтение) представлено методами GetAllAsync и GetByIdAsync.
Update (обновление) представлено методом UpdateAsync.
Delete (удаление) представлено методом DeleteAsync.
 
*/