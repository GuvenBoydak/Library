using FluentValidation.AspNetCore;
using Library.MvcUi.ApiServices;
using Library.MvcUi.Validations.Order;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Library.MvcUi.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Cookie Authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                        .AddCookie(x =>
                        {
                            x.LoginPath = "/Users/Login/";
                            x.AccessDeniedPath = "/Users/Login/";
                        });

            services.AddHttpClient<UserApiService>(opt =>
            {
                opt.BaseAddress = new Uri("https://localhost:7167/api/");
            });

            services.AddHttpClient<OrderApiService>(opt =>
            {
                opt.BaseAddress = new Uri("https://localhost:7167/api/");
            });

            services.AddHttpClient<BookApiService>(opt =>
            {
                opt.BaseAddress = new Uri("https://localhost:7167/api/");
            });

            services.AddHttpClient<CategoryApiService>(opt =>
            {
                opt.BaseAddress = new Uri("https://localhost:7167/api/");
            });

            services.AddHttpClient<WriterApiService>(opt =>
            {
                opt.BaseAddress = new Uri("https://localhost:7167/api/");
            });

            services.AddControllersWithViews()
    .AddFluentValidation((fv => fv.RegisterValidatorsFromAssemblyContaining<AddOrderInputValidator>()));

            //Session
            services.AddSession(x =>
            {
                x.IdleTimeout = TimeSpan.FromMinutes(20);
                x.Cookie.HttpOnly = true;
                x.Cookie.IsEssential = true;
            });


            return services;
        }
    }
}
