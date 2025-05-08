using Soenneker.Normalizers.Base.Abstract;

namespace Soenneker.Normalizers.Ein.Abstract;

/// <summary>
/// A fast and allocation-efficient normalizer that converts raw input into a valid EIN format (XX-XXXXXXX), validating exactly 9 digits and ignoring non-numeric characters.
/// </summary>
public interface IEinNormalizer : IBaseNormalizer<string?, string?>
{
}