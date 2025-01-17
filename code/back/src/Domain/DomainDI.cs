using Domain.Interfaces.UseCases;
using Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DomainDI
{
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        services.AddTransient<IGetFilteredPropertyUseCase, GetFilteredPropertyUseCase>();
        services.AddTransient<IGetTopPropertyUseCase, GetTopPropertyUseCase>();
        return services;
    }
}