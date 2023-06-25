using Library.Domain.Entities;
using Library.Persistance.Context;
using Library.Test.FakeEntity;
using Microsoft.EntityFrameworkCore;

namespace Library.Test.Setup;

public class LibraryTestContext : LibraryDbContext
{
    public LibraryTestContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(FakeBook._GolgeDuserkenBook, FakeBook._KayipHazinesiBook);
        modelBuilder.Entity<Writer>().HasData(FakeWriter._EmmaThompsonWriter, FakeWriter._JohnStevensonWriter);
        modelBuilder.Entity<Category>().HasData(FakeCategory._KorkuCategory, FakeCategory._MaceraCategory);
        modelBuilder.Entity<User>().HasData(FakeUser._AdminUser);
        modelBuilder.Entity<Order>().HasData(FakeOrder._test2Order, FakeOrder._testOrder);
    }
}