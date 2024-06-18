using Microsoft.EntityFrameworkCore;
using test2.Models;

namespace test2.Data;

public class AppDbContext : DbContext
{
    public DbSet<PublishingHouse> PublishingHouses { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    
}