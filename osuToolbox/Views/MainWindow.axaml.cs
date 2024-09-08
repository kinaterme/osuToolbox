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

                // Download the file using HttpClient synchronously
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(destinationPath, fileBytes);
                }
                        // Command to execute
                string command = "unzip /Applications/Rewind.zip -d /Applications"; // replace with the macOS command you want to run

                // Create a new process to run the command
                Process process = new Process();

                // Set process information
                process.StartInfo.FileName = "/bin/bash"; // Bash shell on macOS
                process.StartInfo.Arguments = $"-c \"{command}\""; // -c to pass the command
                process.StartInfo.RedirectStandardOutput = true; // Capture output
                process.StartInfo.RedirectStandardError = true;  // Capture errors
                process.StartInfo.UseShellExecute = false; // Don't use the shell to execute the process
                process.StartInfo.CreateNoWindow = true; // Do not create a command prompt window
                
                // Start the process
                process.Start();

                // Read the output
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                process.WaitForExit(); // Wait for the process to finish
                string command_delete = "rm -f /Applications/Rewind.zip"; // replace with the macOS command you want to run
                process.StartInfo.Arguments = $"-c \"{command_delete}\""; // -c to pass the command
                process.Start();
                process.WaitForExit();
                Process.Start("/Applications/Rewind.app/Contents/MacOS/Rewind");
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

                // Download the file using HttpClient synchronously
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(destinationPath, fileBytes);
                }
                string command = "unzip /Applications/Circleguard.zip -d /Applications"; // replace with the macOS command you want to run

                // Create a new process to run the command
                Process process = new Process();
                
                // Set process information
                process.StartInfo.FileName = "/bin/bash"; // Bash shell on macOS
                process.StartInfo.Arguments = $"-c \"{command}\""; // -c to pass the command
                process.StartInfo.RedirectStandardOutput = true; // Capture output
                process.StartInfo.RedirectStandardError = true;  // Capture errors
                process.StartInfo.UseShellExecute = false; // Don't use the shell to execute the process
                process.StartInfo.CreateNoWindow = true; // Do not create a command prompt window
                
                // Start the process
                process.Start();

                // Read the output
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                process.WaitForExit(); // Wait for the process to finish
                string command_delete = "rm -f /Applications/Circleguard.zip"; // replace with the macOS command you want to run
                process.StartInfo.Arguments = $"-c \"{command_delete}\""; // -c to pass the command
                process.Start();
                process.WaitForExit();
                Process.Start("/Applications/Circleguard.app/Contents/MacOS/Circleguard");
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

                // Download the file using HttpClient synchronously
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(destinationPath, fileBytes);
                }
                        // Command to execute
                string command = "unzip /Applications/MissAnalyzer.zip -d /Applications"; // replace with the macOS command you want to run

                // Create a new process to run the command
                Process process = new Process();

                // Set process information
                process.StartInfo.FileName = "/bin/bash"; // Bash shell on macOS
                process.StartInfo.Arguments = $"-c \"{command}\""; // -c to pass the command
                process.StartInfo.RedirectStandardOutput = true; // Capture output
                process.StartInfo.RedirectStandardError = true;  // Capture errors
                process.StartInfo.UseShellExecute = false; // Don't use the shell to execute the process
                process.StartInfo.CreateNoWindow = true; // Do not create a command prompt window
                
                // Start the process
                process.Start();

                // Read the output
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                process.WaitForExit(); // Wait for the process to finish
                string command_delete = "rm -f /Applications/MissAnalyzer.zip"; // replace with the macOS command you want to run
                process.StartInfo.Arguments = $"-c \"{command_delete}\""; // -c to pass the command
                process.Start();
                process.WaitForExit();
                Process.Start("/Applications/MissAnalyzer.app/Contents/MacOS/OsuMissAnalyzer");
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

                // Download the file using HttpClient synchronously
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(zipFilePath, fileBytes);
                }
                string unzipCommand = $"unzip -q -o {zipFilePath} -d {homeDirectory}/osutoolbox";

                // Create a new process to run the command
                Process process = new Process();
                
                // Set process information
                process.StartInfo.FileName = "/bin/bash"; // Bash shell on macOS
                process.StartInfo.Arguments = $"-c \"{unzipCommand}\""; // -c to pass the command
                process.StartInfo.RedirectStandardOutput = false; // Capture output
                process.StartInfo.RedirectStandardError = false;  // Capture errors
                process.StartInfo.UseShellExecute = false; // Don't use the shell to execute the process
                process.StartInfo.CreateNoWindow = true; // Do not create a command prompt window
                
                // Start the process
                process.Start();

                process.WaitForExit(); // Wait for the process to finish
                string command_delete = $"rm -f {zipFilePath}"; // replace with the macOS command you want to run
                process.StartInfo.Arguments = $"-c \"{command_delete}\""; // -c to pass the command
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
            Console.WriteLine("Running on Linux");
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

                // Download the file using HttpClient synchronously
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(downloadUrl).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    byte[] fileBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                    File.WriteAllBytes(destinationPath, fileBytes);
                }
                string command = "tar xf /Applications/OpenTabletDriver.tar.gz -C /Applications"; // replace with the macOS command you want to run

                // Create a new process to run the command
                Process process = new Process();
                
                // Set process information
                process.StartInfo.FileName = "/bin/bash"; // Bash shell on macOS
                process.StartInfo.Arguments = $"-c \"{command}\""; // -c to pass the command
                process.StartInfo.RedirectStandardOutput = false; // Capture output
                process.StartInfo.RedirectStandardError = false;  // Capture errors
                process.StartInfo.UseShellExecute = false; // Don't use the shell to execute the process
                process.StartInfo.CreateNoWindow = true; // Do not create a command prompt window
                
                // Start the process
                process.Start();

                process.WaitForExit(); // Wait for the process to finish
                string command_delete = "rm -f /Applications/OpenTabletDriver.tar.gz"; // replace with the macOS command you want to run
                process.StartInfo.Arguments = $"-c \"{command_delete}\""; // -c to pass the command
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
        }
        else 
        {
            Console.WriteLine("Unknown operating system");
        }
    }
}