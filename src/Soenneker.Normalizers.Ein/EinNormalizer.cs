using Microsoft.Extensions.Logging;
using Soenneker.Extensions.String;
using Soenneker.Normalizers.Base;
using Soenneker.Normalizers.Ein.Abstract;
using System;
using System.Runtime.CompilerServices;

namespace Soenneker.Normalizers.Ein;

///<inheritdoc cref="IEinNormalizer"/>
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
        if ((uint)input.Length < 9 || input.Length > 20)
            return null;

        Span<char> digits = stackalloc char[9];
        int count = 0;

        foreach (char c in input)
        {
            if (IsAsciiDigit(c))
            {
                if ((uint)count >= 9u)
                    return null; // Too many digits
                digits[count++] = c;
            }
        }

        if (count != 9)
            return null;

        // One allocation: "12-3456789"
        return string.Create(10, digits, static (dst, d) =>
        {
            dst[0] = d[0];
            dst[1] = d[1];
            dst[2] = '-';
            d.Slice(2, 7)
             .CopyTo(dst.Slice(3));
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsAsciiDigit(char c) => (uint)(c - '0') <= 9;
}