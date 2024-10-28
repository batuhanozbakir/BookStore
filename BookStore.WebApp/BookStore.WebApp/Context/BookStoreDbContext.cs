using BookStore.WebApp.Context.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApp.Context
{
    public class BookStoreDbContext : DbContext
    {
        //private static string _connectionString;

        //public BookStoreDbContext(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetConnectionString("BookStoreDbBilkent");
        ////   var test = configuration.GetSection("Ogrenciler:Ank18:Meltem").Value;
        ////    Console.WriteLine("ConStr:" + _connectionString);
        ////    Console.WriteLine("Test:" + test);
        //}

        public BookStoreDbContext(DbContextOptions contextOptions) : base(contextOptions) 
        {
            
        }

        public DbSet<City> Cities { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
    }
}
