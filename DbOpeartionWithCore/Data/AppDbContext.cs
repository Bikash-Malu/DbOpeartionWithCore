using Microsoft.EntityFrameworkCore;

namespace DbOpeartionWithCore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currancy>().HasData(
                new Currancy() { Id = 1, Title = "INR", Description = "Indian Rupee" },
                new Currancy() { Id = 2, Title = "USD", Description = "United States Dollar" },
                new Currancy() { Id = 3, Title = "EUR", Description = "Euro" },
                new Currancy() { Id = 4, Title = "GBP", Description = "British Pound Sterling" },
                new Currancy() { Id = 5, Title = "JPY", Description = "Japanese Yen" }
            );
            modelBuilder.Entity<Lanuage>().HasData(
                new Lanuage { Id = 1, Name = "English", Description = "English Language" },
                new Lanuage { Id = 2, Name = "Spanish", Description = "Spanish Language" },
                new Lanuage { Id = 3, Name = "French", Description = "French Language" },
                new Lanuage { Id = 4, Name = "German", Description = "German Language" }
            );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Lanuage> Lanuages { get; set; }
        public DbSet<Currancy> Curancies { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
    }
}
