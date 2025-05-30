# SnakeNet

## Compatibility

| Operating System | Framework           | Supported |
|------------------|--------------------|-----------|
| Windows 9x/ME    | dotnet9x           | ✅        |
| Windows XP/Vista | .NET Framework 3.5 | ✅        |
| Windows 7/8/8.1  | .NET 6             | ✅        |

All new cross-platform and modern UI development is at [SnakeNetFusion (.NET MAUI)](https://github.com/WhiteWrym18/SnakeNetFusion).

## Getting Started

### Build for .NET 6 (Windows 7+)
```sh
dotnet build -f net6.0-windows
```

### Build for .NET Framework 3.5 (Windows XP/Vista)
Compila su Windows con Visual Studio o MSBuild:
```sh
msbuild /p:Configuration=Release /p:TargetFramework=net35-windows SnakeNet.csproj
```

### Build for dotnet9x (Windows 9x/ME)
- Scarica e configura [dotnet9x](https://github.com/itsmattkc/dotnet9x)
- Compila con il define `NET9X` attivo:
```sh
msbuild /p:Configuration=Release /p:DefineConstants=NET9X /p:TargetFramework=net35-windows SnakeNet.csproj
```

## Note
- Il codice è scritto per garantire compatibilità tripla: dotnet9x, .NET Framework 3.5 e .NET 6.
- Per dotnet9x, alcune API WinForms sono emulate e potrebbero esserci differenze grafiche o di input.
- Per .NET 3.5 e dotnet9x, la compilazione deve essere fatta su Windows.

