using AwesomeAssertions;
using Soenneker.Normalizers.Ein.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Normalizers.Ein.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class EinNormalizerTests : HostedUnitTest
{
    private readonly IEinNormalizer _normalizer;

    public EinNormalizerTests(Host host) : base(host)
    {
        _normalizer = Resolve<IEinNormalizer>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    [Arguments("123456789", "12-3456789")]
    [Arguments("12-3456789", "12-3456789")]
    [Arguments("12 345 6789", "12-3456789")]
    [Arguments("  12.345.6789  ", "12-3456789")]
    [Arguments("12/345\\6789", "12-3456789")]
    [Arguments("abc12-3456789xyz", "12-3456789")]
    public void Should_normalize_valid_EIN_formats(string input, string expected)
    {
        string? result = _normalizer.Normalize(input);
        result.Should().Be(expected);
    }

    [Test]
    [Arguments(null)]
    [Arguments("")]
    [Arguments("   ")]
    [Arguments("12345678")] // too short
    [Arguments("1234567890")] // too long
    [Arguments("abc")] // not enough digits
    [Arguments("12-34-567")] // not enough digits
    [Arguments("!@#$%^&*()")] // no digits
    public void Should_return_null_for_invalid_EIN(string? input)
    {
        string? result = _normalizer.Normalize(input);
        result.Should().BeNull();
    }
}

