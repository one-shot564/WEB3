using lab3.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DAL
{
    public interface IUnitOfWork : IDisposable
    {

        ICategoryRepository Categories { get; }  // Свойство Categories типа ICategoryRepository.
        IRoomRepository Rooms { get; } // Свойство Rooms типа IRoomRepository.
        IReservationRepository Reservations { get; } // Свойство Reservations типа IReservationRepository.
        Task<int> SaveChangesAsync(); // Асинхронно сохраняет все изменения, сделанные в контексте единицы работы.
        Task BeginTransactionAsync(); // Инициирует транзакцию асинхронно. Здесь вы обеспечиваете, чтобы серия операций рассматривалась как единое целое.
        Task CommitTransactionAsync(); // Асинхронно фиксирует транзакцию. Вызывается, когда все операции внутри блока завершены успешно и должны быть сохранены.
        Task RollbackTransactionAsync(); // Асинхронно откатывает транзакцию. Вызывается в случае сбоя любой операции внутри блока, гарантируя, что частичные изменения не будут зафиксированы.
    }


}


/*
 * Свойства репозиториев: Интерфейс раскрывает свойства для различных репозиториев (ICategoryRepository, IRoomRepository, IReservationRepository). 
 * Это позволяет  IUnitOfWork получать доступ к репозиториям и выполнять CRUD-операции над различными сущностями.
 * Управление транзакциями: Для управления транзакциями используются методы BeginTransactionAsync, CommitTransactionAsync и RollbackTransactionAsync.
 * Они гарантируют, что набор операций в рамках единицы работы рассматривается как одна транзакция, которая либо полностью успешна (фиксация), либо полностью неуспешна (откат).
 */