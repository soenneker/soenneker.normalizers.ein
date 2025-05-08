using Microsoft.Extensions.Logging;
using Soenneker.Extensions.String;
using Soenneker.Normalizers.Base;
using Soenneker.Normalizers.Ein.Abstract;
using System;
using Soenneker.Extensions.Char;

namespace Soenneker.Normalizers.Ein;

/// <inheritdoc cref="IEinNormalizer"/>
public sealed class EinNormalizer : BaseNormalizer<string?, string?>, IEinNormalizer
{
    public EinNormalizer(ILogger<EinNormalizer> logger) : base(logger)
    {
    }

    protected override string? NormalizeCore(string? input)
    {
        if (input.IsNullOrWhiteSpace())
            return null;

        // Short-circuit obviously invalid inputs
        if (input.Length is < 9 or > 20)
            return null;

        Span<char> buffer = stackalloc char[9];
        var i = 0;

        foreach (char c in input)
        {
            if (c.IsDigit())
            {
                if (i >= buffer.Length)
                    return null; // Too many digits
                buffer[i++] = c;
            }
        }

        if (i != 9)
            return null;

        return $"{new string(buffer[..2])}-{new string(buffer[2..])}";
    }
}