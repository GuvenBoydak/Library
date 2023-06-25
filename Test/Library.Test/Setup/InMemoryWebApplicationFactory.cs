using Library.Persistance.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Test.Setup;

public class InMemoryWebApplicationFactory<T>:WebApplicationFactory<T> where T:class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing")
            .ConfigureTestServices(services =>
            {
                var options = new DbContextOptionsBuilder<LibraryDbContext>()
                    .UseInMemoryDatabase("InMemoryTest").Options;
                ServiceCollectionServiceExtensions.AddScoped<LibraryDbContext>(services,
                    provider => new LibraryTestContext(options));

                var serviceProvider = ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services);
                using var scope = serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                db.Database.EnsureCreated();
            });
    }  
}