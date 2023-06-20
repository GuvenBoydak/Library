using Library.Application.Repositories;
using Library.Application.Services;
using Library.Application.UnitOfWork;
using Library.Persistance.Context;
using Library.Persistance.Repositories;
using Library.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<LibraryDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IWriterRepository, WriterRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        
        services.AddScoped<IAuthService, AuthService>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        
        

    }
}