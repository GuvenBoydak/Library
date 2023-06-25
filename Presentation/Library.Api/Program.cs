using FluentValidation.AspNetCore;
using Library.Api.Filters;
using Library.Application;
using Library.Application.Validations.User;
using Library.Persistance;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ValidatorFilterAttribute>();
    })
    .AddFluentValidation(configuration =>
        configuration.RegisterValidatorsFromAssemblyContaining<RegisterUserCommandValidator>());

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}