using Soenneker.Normalizers.Base.Abstract;

namespace Soenneker.Normalizers.Ein.Abstract;

/// <summary>
/// Normalizes input containing exactly nine ASCII digits to the canonical EIN display format <c>XX-XXXXXXX</c>.
/// </summary>
public interface IEinNormalizer : IBaseNormalizer<string?, string?>
{
}
