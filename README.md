# osu! toolbox
A toolbox containing popular tools used for osu!.
This toolbox was made for seamless setup of the tools on Linux and Mac, as some tools aren't built for them.
You can still use this toolbox on Windows, though.

This is still in VERY early development, and is missing most of the tools.

![Screenshot 2024-09-07 at 11 21 20 PM](https://github.com/user-attachments/assets/22f45eef-b3ee-4ce3-81aa-1242dc6c1a49)

## What works
MacOS: 
* Rewind
* Circleguard
* MissAnalyzer (have to extract maps in folders)
* KeyOverlay
* OpenTabletDriver

## What doesn't work
Windows: Everything<br/>

MacOS: 
* StreamCompanion/gosumemory
* Anti Mindblock
* osu! trainer<br/>

Linux: Everything

## How to build
### Windows:<br/>

1. Download .NET 8 https://dotnet.microsoft.com/en-us/download/dotnet/8.0
  
2. Build the toolbox
```
git clone https://github.com/kinaterme/osuToolbox
cd osuToolbox/osuToolbox.Desktop
dotnet build
dotnet publish -r win-x64 -c Release
cd bin/Release/net8.0/win-x64/publish
explorer .
```
3. Run osuToolbox.Desktop.exe

### macOS (Apple Silicon):<br/>

1. Download .NET 8 https://dotnet.microsoft.com/en-us/download/dotnet/8.0

2. Build the toolbox and run it
```
mkdir build
cd build
git clone https://github.com/kinaterme/osuToolbox
cd osuToolbox/osuToolbox.Desktop
dotnet build
dotnet publish -r osx-arm64 -c Release
cd bin/Release/net8.0/osx-arm64/publish
./osuToolbox.Desktop
```

### macOS (Intel):<br/>

1. Install .NET 8 https://dotnet.microsoft.com/en-us/download/dotnet/8.0

2. Build the toolbox and run it
```
mkdir build
cd build
git clone https://github.com/kinaterme/osuToolbox
cd osuToolbox/osuToolbox.Desktop
dotnet build
dotnet publish -r osx-x64 -c Release
cd bin/Release/net8.0/osx-x64/publish
./osuToolbox.Desktop
```
### Linux:<br/>

1. Install .NET 8 https://dotnet.microsoft.com/en-us/download/dotnet/8.0 (or use a package manager)

2. Build the toolbox and run it
```
mkdir build
cd build
git clone https://github.com/kinaterme/osuToolbox
cd osuToolbox/osuToolbox.Desktop
dotnet build
dotnet publish -r linux-x64 -c Release
cd bin/Release/net8.0/linux-x64/publish
./osuToolbox.Desktop
```

