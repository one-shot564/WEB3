using Microsoft.EntityFrameworkCore;

namespace lab3.DAL
{
    public class HotelContext : DbContext
    {
        // Определяем DbSet для каждой сущности
        public DbSet<Room> Rooms { get; set; } // Свойство Rooms типа DbSet<Room>.
        public DbSet<Category> Categories { get; set; } // Свойство Categories типа DbSet<Category>.
        public DbSet<Reservation> Reservations { get; set; } // Свойство Reservations типа DbSet<Reservation>.

        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        // Настройка моделей и их связей будет здесь
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
