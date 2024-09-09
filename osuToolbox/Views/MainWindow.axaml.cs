using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;

namespace osuToolbox.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void RewindClickHandler(object sender, RoutedEventArgs args) {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.WriteLine("Running on Windows");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Console.WriteLine("Running on macOS");
            if (Directory.Exists("/Applications/Rewind.app")) {
                Console.WriteLine("rewind installed");
                Process.Start("/Applications/Rewind.app/Contents/MacOS/Rewind");
            }
            else
            {
                Console.WriteLine("rewind is not installed");
                string downloadUrl = "https://github.com/abstrakt8/rewind/releases/download/v0.2.0/Rewind-0.2.0-mac.zip";
                string destinationPath = "/Applications/Rewind.zip";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(destinationPath, fileBytes);
                }
                string command = "unzip /Applications/Rewind.zip -d /Applications";

                Process process = new Process();

                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{command}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                process.WaitForExit();
                string command_delete = "rm -f /Applications/Rewind.zip";
                process.StartInfo.Arguments = $"-c \"{command_delete}\"";
                process.Start();
                process.WaitForExit();
                Process.Start("/Applications/Rewind.app/Contents/MacOS/Rewind");
            }
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string rewindPath = Path.Combine(homeDirectory, "osutoolbox/Rewind");
            string finalFilePath = Path.Combine(homeDirectory, "osutoolbox/Rewind/Rewind.AppImage");

            Console.WriteLine("Running on Linux");
            if (Directory.Exists(rewindPath))
            {
                Console.WriteLine("rewind installed");
                string rewindExecutable = Path.Combine(rewindPath, "Rewind.AppImage");
                Process.Start(new ProcessStartInfo
                {
                    FileName = rewindExecutable,
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("rewind is not installed");
                Directory.CreateDirectory(rewindPath);
                string downloadUrl = "https://github.com/abstrakt8/rewind/releases/download/v0.2.0/Rewind-0.2.0.AppImage";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(finalFilePath, fileBytes);
                }

                string rewindExecutable = Path.Combine(rewindPath, "Rewind.AppImage");
                Process.Start(new ProcessStartInfo
                {
                    FileName = rewindExecutable,
                    UseShellExecute = true
                });
            }
        }
        else
        {
            Console.WriteLine("Unknown Operating System");
        }


    }

    public void CircleguardClickHandler(object sender, RoutedEventArgs args) {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.WriteLine("Running on Windows");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Console.WriteLine("Running on macOS");
            if (Directory.Exists("/Applications/Circleguard.app")) {
                Console.WriteLine("circleguard installed");
                Process.Start("/Applications/Circleguard.app/Contents/MacOS/Circleguard");
            }
            else
            {
                Console.WriteLine("circleguard is not installed");
                string downloadUrl = "https://github.com/circleguard/circleguard/releases/download/v2.15.6/Circleguard_osx.app.zip";
                string destinationPath = "/Applications/Circleguard.zip";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(destinationPath, fileBytes);
                }
                string command = "unzip /Applications/Circleguard.zip -d /Applications";

                Process process = new Process();
                
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{command}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                process.WaitForExit();
                string command_delete = "rm -f /Applications/Circleguard.zip";
                process.StartInfo.Arguments = $"-c \"{command_delete}\"";
                process.Start();
                process.WaitForExit();
                Process.Start("/Applications/Circleguard.app/Contents/MacOS/Circleguard");
            }
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Console.WriteLine("Running on Linux");
            if (Directory.Exists($"$HOME/test")) {
                Console.WriteLine("exists");
            }
            else {
                Console.WriteLine("does not");
            }
        }
        else
        {
            Console.WriteLine("Unknown Operating System");
        }
    }

    public void MissAnalyzerClickHandler(object sender, RoutedEventArgs args) {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.WriteLine("Running on Windows");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Console.WriteLine("Running on macOS");
            if (Directory.Exists("/Applications/MissAnalyzer.app")) {
                Console.WriteLine("missanalyzer installed");
                Process.Start("/Applications/MissAnalyzer.app/Contents/MacOS/OsuMissAnalyzer");
            }
            else
            {
                Console.WriteLine("missanalyzer is not installed");
                string downloadUrl = "https://raw.githubusercontent.com/kinaterme/osuToolbox/main/bins/MacOS/MissAnalyzer.zip";
                string destinationPath = "/Applications/MissAnalyzer.zip";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(destinationPath, fileBytes);
                }
                string command = "unzip /Applications/MissAnalyzer.zip -d /Applications";

                Process process = new Process();

                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{command}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                process.WaitForExit();
                string command_delete = "rm -f /Applications/MissAnalyzer.zip";
                process.StartInfo.Arguments = $"-c \"{command_delete}\"";
                process.Start();
                process.WaitForExit();
                Process.Start("/Applications/MissAnalyzer.app/Contents/MacOS/OsuMissAnalyzer");
            }
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string missAnalyzerPath = Path.Combine(homeDirectory, "osutoolbox/MissAnalyzer");
            string zipFilePath = Path.Combine(homeDirectory, "osutoolbox/MissAnalyzer/MissAnalyzer.zip");

            Console.WriteLine("Running on Linux");
            if (Directory.Exists(missAnalyzerPath))
            {
                Console.WriteLine("missanalyzer installed");
                string missAnalyzerExecutable = Path.Combine(missAnalyzerPath, "OsuMissAnalyzer");
                Process.Start(new ProcessStartInfo
                {
                    FileName = missAnalyzerExecutable,
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("missanalyzer is not installed");
                Directory.CreateDirectory(missAnalyzerPath);
                string downloadUrl = "https://github.com/ThereGoesMySanity/osuMissAnalyzer/releases/download/v1.6.0/OsuMissAnalyzer_linux.zip";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(zipFilePath, fileBytes);
                }

                string unzipCommand = $"unzip -q -o {zipFilePath} -d {homeDirectory}/osutoolbox/MissAnalyzer";

                Process process = new Process();
                
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{unzipCommand}\"";
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();

                process.WaitForExit();
                string command_delete = $"rm -f {zipFilePath}";
                process.StartInfo.Arguments = $"-c \"{command_delete}\"";
                process.Start();
                process.WaitForExit();


                string missAnalyzerExecutable = Path.Combine(missAnalyzerPath, "OsuMissAnalyzer");
                Process.Start(new ProcessStartInfo
                {
                    FileName = missAnalyzerExecutable,
                    UseShellExecute = true
                });
            }
        }
        else
        {
            Console.WriteLine("Unknown Operating System");
        }
    }

    public void KeyOverlayClickHandler(object sender, RoutedEventArgs args) {
        string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string keyOverlayPath = Path.Combine(homeDirectory, "osutoolbox/KeyOverlay");
        string zipFilePath = Path.Combine(homeDirectory, "osutoolbox/KeyOverlay.zip");

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.WriteLine("Running on Windows");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Console.WriteLine("Running on macOS");
            if (Directory.Exists(keyOverlayPath))
            {
                Console.WriteLine("KeyOverlay installed");
                string keyOverlayExecutable = Path.Combine(keyOverlayPath, "KeyOverlay");
                Process.Start(new ProcessStartInfo
                {
                    FileName = keyOverlayExecutable,
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("keyoverlay is not installed");
                string downloadUrl = "https://github.com/Blondazz/KeyOverlay/releases/download/v1.0.6/KeyOverlay-macos-latest.zip";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(zipFilePath, fileBytes);
                }
                string unzipCommand = $"unzip -q -o {zipFilePath} -d {homeDirectory}/osutoolbox";

                Process process = new Process();
                
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{unzipCommand}\"";
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();

                process.WaitForExit();
                string command_delete = $"rm -f {zipFilePath}";
                process.StartInfo.Arguments = $"-c \"{command_delete}\"";
                process.Start();
                process.WaitForExit();
                string keyOverlayExecutable = Path.Combine(keyOverlayPath, "KeyOverlay");
                Process.Start(new ProcessStartInfo
                {
                    FileName = keyOverlayExecutable,
                    UseShellExecute = true
                });
            }
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            string homeDirectoryLinux = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string KeyOverlayPath = Path.Combine(homeDirectory, "osutoolbox/KeyOverlay");
            string zipFilePathLinux = Path.Combine(homeDirectory, "osutoolbox/KeyOverlay/KeyOverlay.zip");

            Console.WriteLine("Running on Linux");
            if (Directory.Exists(KeyOverlayPath))
            {
                Console.WriteLine("missanalyzer installed");
                string KeyOverlayExecutable = Path.Combine(KeyOverlayPath, "KeyOverlay");
                Process.Start(new ProcessStartInfo
                {
                    FileName = KeyOverlayExecutable,
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("KeyOverlay is not installed");
                Directory.CreateDirectory(KeyOverlayPath);
                string downloadUrl = "https://github.com/Blondazz/KeyOverlay/releases/download/v1.0.6/KeyOverlay-ubuntu-latest.zip";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(zipFilePathLinux, fileBytes);
                }

                string unzipCommand = $"unzip -q -o {zipFilePathLinux} -d {homeDirectoryLinux}/osutoolbox/KeyOverlay";

                Process process = new Process();
                
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{unzipCommand}\"";
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();

                process.WaitForExit();
                string command_delete = $"rm -f {zipFilePathLinux}";
                process.StartInfo.Arguments = $"-c \"{command_delete}\"";
                process.Start();
                process.WaitForExit();
                string KeyOverlayExecutable = Path.Combine(KeyOverlayPath, "KeyOverlay");
                string command_runAsExecutable = $"chmod +x {KeyOverlayExecutable}";
                process.StartInfo.Arguments = $"-c \"{command_runAsExecutable}\"";
                process.Start();
                process.WaitForExit();

                Process.Start(new ProcessStartInfo
                {
                    FileName = KeyOverlayExecutable,
                    UseShellExecute = true
                });
            }
        }
        else
        {
            Console.WriteLine("Unknown Operating System");
        }
    }

    public void OpenTabletDriverClickHandler(object sender, RoutedEventArgs args) {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.WriteLine("Running on Windows");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Console.WriteLine("Running on macOS");
            if (Directory.Exists("/Applications/OpenTabletDriver.app")) {
                Console.WriteLine("tablet installed");
                Process.Start("/Applications/OpenTabletDriver.app/Contents/MacOS/OpenTabletDriver.UX.MacOS");
            }
            else
            {
                Console.WriteLine("tablet is not installed");
                string downloadUrl = "https://github.com/OpenTabletDriver/OpenTabletDriver/releases/latest/download/OpenTabletDriver.osx-x64.tar.gz";
                string destinationPath = "/Applications/OpenTabletDriver.tar.gz";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(destinationPath, fileBytes);
                }
                string command = "tar xf /Applications/OpenTabletDriver.tar.gz -C /Applications";

                Process process = new Process();
                
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{command}\"";
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();

                process.WaitForExit();
                string command_delete = "rm -f /Applications/OpenTabletDriver.tar.gz";
                process.StartInfo.Arguments = $"-c \"{command_delete}\"";
                process.Start();
                process.WaitForExit();
                Process.Start("/Applications/OpenTabletDriver.app/Contents/MacOS/OpenTabletDriver.UX.MacOS");
            }
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Console.WriteLine("Running on Linux");
        }
        else
        {
            Console.WriteLine("Unknown Operating System");
        }
    }
    public void DanserClickHandler(object sender, RoutedEventArgs args) {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) 
        {
            Console.WriteLine("Running on Windows");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) 
        {
            Console.WriteLine("Running on MacOS");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) 
        {
            Console.WriteLine("Running on Linux");
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string danserPath = Path.Combine(homeDirectory, "osutoolbox/danser");
            string zipFilePath = Path.Combine(homeDirectory, "osutoolbox/danser/danser.zip");

            Console.WriteLine("Running on Linux");
            if (Directory.Exists(danserPath))
            {
                Console.WriteLine("danser installed");
                string danserExecutable = Path.Combine(danserPath, "danser");
                Process.Start(new ProcessStartInfo
                {
                    FileName = danserExecutable,
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("danser is not installed");
                Directory.CreateDirectory(danserPath);
                string downloadUrl = "https://github.com/Wieku/danser-go/releases/download/0.9.1/danser-0.9.1-linux.zip";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(zipFilePath, fileBytes);
                }

                string unzipCommand = $"unzip -q -o {zipFilePath} -d {homeDirectory}/osutoolbox/danser";

                Process process = new Process();
                
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{unzipCommand}\"";
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();

                process.WaitForExit();
                string command_delete = $"rm -f {zipFilePath}";
                process.StartInfo.Arguments = $"-c \"{command_delete}\"";
                process.Start();
                process.WaitForExit();
                string danserExecutable = Path.Combine(danserPath, "danser");
                string command_setAsExecutable = $"chmod +x {danserExecutable}";
                process.StartInfo.Arguments = $"-c \"{command_setAsExecutable}\"";
                process.Start();
                process.WaitForExit();



                Process.Start(new ProcessStartInfo
                {
                    FileName = danserExecutable,
                    UseShellExecute = true
                });
            }
        }
        else 
        {
            Console.WriteLine("Unknown operating system");
        }
    }
    public void OsuTrainerClickHandler(object sender, RoutedEventArgs args) 
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) 
        {
            Console.WriteLine("Running on Windows.");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) 
        {
            Console.WriteLine("Running on MacOS.");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) 
        {
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string osuTrainerPath = Path.Combine(homeDirectory, "osutoolbox/osutrainer");
            string zipFilePath = Path.Combine(homeDirectory, "osutoolbox/osutrainer/osutrainer.tar.zst");

            Console.WriteLine("Running on Linux");
            if (Directory.Exists(osuTrainerPath))
            {
                Console.WriteLine("osutrainer installed");
                string osuTrainerExecutable = Path.Combine(osuTrainerPath, "cosu-trainer-x86_64.AppImage");
                string osuMemExecutable = Path.Combine(osuTrainerPath, "osumem");
                Process.Start(new ProcessStartInfo
                {
                    FileName = osuMemExecutable,
                    UseShellExecute = true
                });
                Process.Start(new ProcessStartInfo
                {
                    FileName = osuTrainerExecutable,
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("osutrainer is not installed");
                Directory.CreateDirectory(osuTrainerPath);
                string downloadUrl = "https://github.com/hwsmm/cosutrainer/releases/download/0.12/cosu-trainer-bin.tar.zst";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(zipFilePath, fileBytes);
                }

                string unzipCommand = $"tar xf {zipFilePath} -C {homeDirectory}/osutoolbox/osutrainer";

                Process process = new Process();
                
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{unzipCommand}\"";
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();

                process.WaitForExit();
                string command_delete = $"rm -f {zipFilePath}";
                process.StartInfo.Arguments = $"-c \"{command_delete}\"";
                process.Start();
                process.WaitForExit();


                string osuMemExecutable = Path.Combine(osuTrainerPath, "osumem");
                string osuTrainerExecutable = Path.Combine(osuTrainerPath, "cosu-trainer-x86_64.AppImage");
                Process.Start(new ProcessStartInfo
                {
                    FileName = osuMemExecutable,
                    UseShellExecute = true
                });
                Process.Start(new ProcessStartInfo
                {
                    FileName = osuTrainerExecutable,
                    UseShellExecute = true
                });
            }
        }
    }
    
    public void AntiMindblockClickHandler(object sender, RoutedEventArgs args) 
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) 
        {

        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) 
        {

        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) 
        {
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string antiMindblockPath = Path.Combine(homeDirectory, "osutoolbox/Anti_Mindblock");
            string zipFilePath = Path.Combine(homeDirectory, "osutoolbox/AntiMindblock.zip");

            Console.WriteLine("Running on Linux");
            if (Directory.Exists(antiMindblockPath))
            {
                Console.WriteLine("antimindblock installed");
                string antiMindblockExecutable = Path.Combine(antiMindblockPath, "main.dist/main.bin");
                Process.Start(new ProcessStartInfo
                {
                    FileName = antiMindblockExecutable,
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("antimindblock is not installed");
                string downloadUrl = "https://github.com/kinaterme/anti-mindblock/releases/download/releases/AntiMindblock.zip";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(zipFilePath, fileBytes);
                }

                string unzipCommand = $"unzip -q -o {zipFilePath} -d {homeDirectory}/osutoolbox";

                Process process = new Process();
                
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{unzipCommand}\"";
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();

                process.WaitForExit();
                string command_delete = $"rm -f {zipFilePath}";
                process.StartInfo.Arguments = $"-c \"{command_delete}\"";
                process.Start();
                process.WaitForExit();


                string antiMindblockExecutable = Path.Combine(antiMindblockPath, "main.dist/main.bin");
                Process.Start(new ProcessStartInfo
                {
                    FileName = antiMindblockExecutable,
                    UseShellExecute = true
                });
            }
        }
        else 
        {
            Console.WriteLine("Unknown operating system");
        }
    }

    public void GosumemoryClickHandler(object sender, RoutedEventArgs args) 
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) 
        {

        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) 
        {
            
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) 
        {
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string gosumemoryPath = Path.Combine(homeDirectory, "osutoolbox/gosumemory");
            string zipFilePath = Path.Combine(homeDirectory, "osutoolbox/gosumemory/gosumemory.zip");

            Console.WriteLine("Running on Linux");
            if (Directory.Exists(gosumemoryPath))
            {
                Console.WriteLine("gosumemory installed");
                string gosumemoryExecutable = Path.Combine(gosumemoryPath, "gosumemory");
                Process.Start(new ProcessStartInfo
                {
                    FileName = gosumemoryExecutable,
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("gosumemory is not installed");
                Directory.CreateDirectory(gosumemoryPath);
                string downloadUrl = "https://github.com/l3lackShark/gosumemory/releases/download/1.3.9/gosumemory_linux_amd64.zip";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(zipFilePath, fileBytes);
                }

                string unzipCommand = $"unzip -q -o {zipFilePath} -d {homeDirectory}/osutoolbox/gosumemory";

                Process process = new Process();
                
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{unzipCommand}\"";
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();

                process.WaitForExit();
                string command_delete = $"rm -f {zipFilePath}";
                process.StartInfo.Arguments = $"-c \"{command_delete}\"";
                process.Start();
                process.WaitForExit();
                string gosumemoryExecutable = Path.Combine(gosumemoryPath, "gosumemory");
                string command_setAsExecutable = $"chmod +x {gosumemoryExecutable}";
                process.StartInfo.Arguments = $"-c \"{command_setAsExecutable}\"";
                process.Start();
                process.WaitForExit();

                
                Process.Start(new ProcessStartInfo
                {
                    FileName = gosumemoryExecutable,
                    UseShellExecute = true
                });
            }
        }
        else 
        {

        }
    }
}