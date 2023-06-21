using AutoMapper;
using Library.Application.Mapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection service)
    {
        // MediatR
        service.AddMediatR(typeof(ServiceRegistration));

        // AutoMapper
        var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MapperProfile()); });
        service.AddSingleton(mapperConfig.CreateMapper());

        return service;
    }
}