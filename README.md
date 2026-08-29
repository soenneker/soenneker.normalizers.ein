[![](https://img.shields.io/nuget/v/soenneker.normalizers.ein.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.ein/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.ein/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.ein/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.normalizers.ein.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.ein/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.ein/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.ein/actions/workflows/codeql.yml)

# Soenneker.Normalizers.Ein

A fast and allocation-efficient normalizer that converts raw input into a valid EIN format (XX-XXXXXXX), validating exactly 9 digits and ignoring non-numeric characters.

## Install

```bash
dotnet add package Soenneker.Normalizers.Ein
```

## Quick start

```csharp
using Soenneker.Normalizers.Ein.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddEinNormalizerAsSingleton();
```

Adds `IEinNormalizer` as a singleton service.

## What you get

- `IEinNormalizer` — A fast and allocation-efficient normalizer that converts raw input into a valid EIN format (XX-XXXXXXX), validating exactly 9 digits and ignoring non-numeric characters.
- `EinNormalizerRegistrar` — A fast and allocation-efficient normalizer that converts raw input into a valid EIN format (XX-XXXXXXX), validating exactly 9 digits and ignoring non-numeric characters.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `EinNormalizerRegistrar.AddEinNormalizerAsSingleton(services)` | Adds `IEinNormalizer` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `EinNormalizerRegistrar.AddEinNormalizerAsScoped(services)` | Adds `IEinNormalizer` as a scoped service. | The same service collection, so additional registrations can be chained. |
