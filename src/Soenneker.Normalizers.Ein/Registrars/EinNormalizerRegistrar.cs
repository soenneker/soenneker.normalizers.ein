using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Normalizers.Ein.Abstract;

namespace Soenneker.Normalizers.Ein.Registrars;

/// <summary>
/// Registers the EIN normalizer.
/// </summary>
public static class EinNormalizerRegistrar
{
    /// <summary>
    /// Adds <see cref="IEinNormalizer"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddEinNormalizerAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IEinNormalizer, EinNormalizer>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IEinNormalizer"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddEinNormalizerAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IEinNormalizer, EinNormalizer>();

        return services;
    }
}
