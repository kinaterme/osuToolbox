# osu! toolbox
A toolbox containing popular tools used for osu!.
This toolbox was made for seamless setup of the tools on Linux and Mac, as some tools aren't built for them.
You can still use this toolbox on Windows, though.

This is still in VERY early development, and is missing most of the tools.

![toolbox](https://github.com/user-attachments/assets/a1f09e73-ec7f-4045-8475-51f04331817e)

* [How to build](https://github.com/kinaterme/osuToolbox?tab=readme-ov-file#how-to-build)
* [MissAnalyzer on macOS](https://github.com/kinaterme/osuToolbox?tab=readme-ov-file#how-to-use-missanalyzer-on-macos)

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
* Danser
* osu! trainer<br/>

Linux: Everything

## How to build
### Windows:<br/>

1. Install .NET 8 https://dotnet.microsoft.com/en-us/download/dotnet/8.0
  
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

1. Install .NET 8 https://dotnet.microsoft.com/en-us/download/dotnet/8.0

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

## How to use MissAnalyzer on macOS
1. Unzip a map (.osz) into a folder
2. Get your replay file (.osr)
3. Launch MissAnalyzer through the toolbox
4. Load replay file
5. Load .osu file inside the map's folder (you have to match the difficulty of the map and the replay)

![missanalyzer](https://github.com/user-attachments/assets/7e11716e-fab8-499f-8bfa-e3eed258461a)
