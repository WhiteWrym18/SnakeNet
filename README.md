# SnakeNet

[![.NET 6 Build](https://github.com/WhiteWrym18/SnakeNetClassic/actions/workflows/build-dotnet6-windows7.yml/badge.svg?branch=main)](https://github.com/WhiteWrym18/SnakeNetClassic/actions/workflows/build-dotnet6-windows7.yml)
[![.NET Framework 3.5 Build](https://github.com/WhiteWrym18/SnakeNetClassic/actions/workflows/net35.yml/badge.svg?branch=main)](https://github.com/WhiteWrym18/SnakeNetClassic/actions/workflows/net35.yml)




## Compatibility

| Operating System   | Framework           | Supported |
|-------------------|--------------------|-----------|
| Windows 9x/ME     | dotnet9x           | ✅        |
| Windows XP/Vista  | .NET Framework 3.5 | ✅        |
| Windows 7/8/8.1   | .NET 6             | ✅        |

All new cross-platform and modern UI development is at [SnakeNetFusion (.NET MAUI)](https://github.com/WhiteWrym18/SnakeNetFusion).

## Getting Started

### Build for .NET 6 (Windows 7+)
```sh
dotnet build -f net6.0-windows
```

### Build for .NET Framework 3.5 (Windows XP/Vista)
Build on Windows with Visual Studio or MSBuild:
```sh
msbuild /p:Configuration=Release /p:TargetFramework=net35-windows SnakeNet.csproj
```

### Build for dotnet9x (Windows 9x/ME)
- Download and set up [dotnet9x](https://github.com/itsmattkc/dotnet9x)
- Build with the `NET9X` define enabled:
```sh
msbuild /p:Configuration=Release /p:DefineConstants=NET9X /p:TargetFramework=net35-windows SnakeNet.csproj
```

## Notes
- The code is written for triple compatibility: dotnet9x, .NET Framework 3.5, and .NET 6.
- For dotnet9x, some WinForms APIs are emulated and there may be graphical or input differences.
- For .NET 3.5 and dotnet9x, you must build on Windows.


