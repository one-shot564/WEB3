using lab3.DAL.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace lab3.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly HotelContext _context; // Контекст базы данных Entity Framework.
        private bool disposed = false; // Чтобы отследить, был ли объект утилизирован
        private IDbContextTransaction _transaction;  // Для управления транзакциями в БД

        public UnitOfWork(HotelContext context) // Конструктор, инициализирующий репозитории и контекст базы данных
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Выбрасывает исключение, если контекст не предоставлен.
            Categories = new CategoryRepository(_context); // Инициализирует репозитории, передавая им контекст базы данных.
            Rooms = new RoomRepository(_context); // Инициализирует репозитории, передавая им контекст базы данных.
            Reservations = new ReservationRepository(_context); // Инициализирует репозитории, передавая им контекст базы данных.
        }
        // Свойства для доступа к репозиториям.
        public ICategoryRepository Categories { get; private set; } // Свойство Categories типа ICategoryRepository.
        public IRoomRepository Rooms { get; private set; } // Свойство Rooms типа IRoomRepository.
        public IReservationRepository Reservations { get; private set; } // Свойство Reservations типа IReservationRepository.

        public async Task<int> SaveChangesAsync() // Зафиксируйте все изменения, сделанные в контексте, в базе данных
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync() // Начинает транзакцию
        {
            _transaction = await _context.Database.BeginTransactionAsync(); // Начинает транзакцию в базе данных и сохраняет ее в поле _transaction.
        }

        public async Task CommitTransactionAsync() // Завершает транзакцию
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync() // Откатывает транзакцию
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        protected virtual void Dispose(bool disposing) // Реализация паттерна Dispose
        {
            if (!disposed)
            {
                if (disposing)
                {
                    
                    _context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}


/*
 * Инициализация репозитория: В конструкторе создаются экземпляры CategoryRepository, RoomRepository и ReservationRepository, которые ассоциируются с одним и тем же контекстом базы данных,
 * гарантируя, что все операции, выполняемые через эти хранилища, являются частью одной и той же единицы работы.
 * Управление транзакциями: Методы BeginTransactionAsync, CommitTransactionAsync и RollbackTransactionAsync управляют жизненным циклом транзакции
 * Фиксация изменений: Метод SaveChangesAsync фиксирует все внесенные в базу данных изменения
 *  Реализация IDisposable позволяет правильно освобождать ресурсы. Метод Dispose гарантирует, что контекст базы данных и любые другие управляемые ресурсы будут утилизированы, когда UnitOfWork больше не нужен.
 */