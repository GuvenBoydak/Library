using Library.Application.Repositories;
using Library.Application.Services;
using Library.Application.UnitOfWork;
using Library.Persistance.Context;
using Library.Persistance.Repositories;
using Library.Persistance.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Library.Persistance;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IWriterRepository, WriterRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        
        services.AddScoped<IAuthService, AuthService>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddJwtBearer(options =>
         {
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = false,
                 ValidateAudience = false,
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("SecurityKey").Value))
             };
         });

        return services;
    }
}