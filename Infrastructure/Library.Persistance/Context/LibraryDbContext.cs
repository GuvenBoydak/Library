using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Context;

public class LibraryDbContext:DbContext
{
    public LibraryDbContext(DbContextOptions options):base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    
    
}