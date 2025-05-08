using FluentAssertions;
using Soenneker.Normalizers.Ein.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Normalizers.Ein.Tests;

[Collection("Collection")]
public class EinNormalizerTests : FixturedUnitTest
{
    private readonly IEinNormalizer _normalizer;

    public EinNormalizerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _normalizer = Resolve<IEinNormalizer>(true);
    }

    [Fact]
    public void Default()
    {

    }

    [Theory]
    [InlineData("123456789", "12-3456789")]
    [InlineData("12-3456789", "12-3456789")]
    [InlineData("12 345 6789", "12-3456789")]
    [InlineData("  12.345.6789  ", "12-3456789")]
    [InlineData("12/345\\6789", "12-3456789")]
    [InlineData("abc12-3456789xyz", "12-3456789")]
    public void Should_normalize_valid_EIN_formats(string input, string expected)
    {
        string? result = _normalizer.Normalize(input);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("12345678")] // too short
    [InlineData("1234567890")] // too long
    [InlineData("abc")] // not enough digits
    [InlineData("12-34-567")] // not enough digits
    [InlineData("!@#$%^&*()")] // no digits
    public void Should_return_null_for_invalid_EIN(string? input)
    {
        string? result = _normalizer.Normalize(input);
        result.Should().BeNull();
    }
}
