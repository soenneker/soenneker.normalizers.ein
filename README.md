# Soenneker.Normalizers.Ein
[![](https://img.shields.io/nuget/v/soenneker.normalizers.ein.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.ein/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.ein/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.ein/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.normalizers.ein.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.ein/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.ein/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.ein/actions/workflows/codeql.yml)

Extracts nine ASCII digits from user input and formats them as `XX-XXXXXXX`.

## Installation

```bash
dotnet add package Soenneker.Normalizers.Ein
```

## Registration

```csharp
using Soenneker.Normalizers.Ein.Registrars;

builder.Services.AddEinNormalizerAsSingleton();
// or: builder.Services.AddEinNormalizerAsScoped();
```

The implementation has no mutable per-call state and can be shared as a singleton.

## Usage

```csharp
using Soenneker.Normalizers.Ein.Abstract;

string? normalized = normalizer.Normalize("12 345 6789");
// "12-3456789"
```

Behavior is intentionally narrow:

| Input | Result |
| --- | --- |
| `123456789` | `12-3456789` |
| `12-3456789` | `12-3456789` |
| `abc12.345.6789xyz` | `12-3456789` |
| `12345678` | `null` |
| `1234567890` | `null` |
| null, empty, or whitespace | `null` |

Non-ASCII digits do not count. Non-numeric characters are ignored, the original input must be between 9 and 20 characters, and the result is `null` unless exactly nine digits remain.

This is formatting, not EIN verification. It does not validate IRS prefix assignments, confirm that an EIN was issued, or establish that the identifier belongs to an organization. Perform any required business verification separately.

EINs are sensitive identifiers. Avoid logging raw or normalized values, and apply appropriate access controls and retention rules when storing them.
