using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Normalizers.Ein.Abstract;

namespace Soenneker.Normalizers.Ein.Registrars;

/// <summary>
/// A fast and allocation-efficient normalizer that converts raw input into a valid EIN format (XX-XXXXXXX), validating exactly 9 digits and ignoring non-numeric characters.
/// </summary>
public static class EinNormalizerRegistrar
{
    /// <summary>
    /// Adds <see cref="IEinNormalizer"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddEinNormalizerAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IEinNormalizer, EinNormalizer>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IEinNormalizer"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddEinNormalizerAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IEinNormalizer, EinNormalizer>();

        return services;
    }
}
