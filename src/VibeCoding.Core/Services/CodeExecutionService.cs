using System.Diagnostics;
using System.Text;
using VibeCoding.Core.Models;

namespace VibeCoding.Core.Services;

public class CodeExecutionService : ICodeExecutionService
{
    public async Task<ExecutionResult> ExecuteCodeAsync(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            return new ExecutionResult
            {
                Success = false,
                Output = "No code provided.",
                ErrorMessage = "No code provided."
            };
        }

        try
        {
            // Create a temporary directory for the code execution
            var tempDir = Path.Combine(Path.GetTempPath(), $"VibeCoding_{Guid.NewGuid()}");
            Directory.CreateDirectory(tempDir);

            try
            {
                var sourceFile = Path.Combine(tempDir, "Program.cs");
                await File.WriteAllTextAsync(sourceFile, code);

                // Create a temporary project file
                var projectFile = Path.Combine(tempDir, "TempProject.csproj");
                var projectContent = @"<Project Sdk=""Microsoft.NET.Sdk"">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>";
                await File.WriteAllTextAsync(projectFile, projectContent);

                // Build the project
                var buildResult = await RunProcessAsync("dotnet", $"build \"{projectFile}\" --configuration Release", tempDir);
                
                if (!buildResult.Success)
                {
                    return new ExecutionResult
                    {
                        Success = false,
                        Output = buildResult.Output,
                        ErrorMessage = "Compilation failed."
                    };
                }

                // Run the compiled program
                var exePath = Path.Combine(tempDir, "bin", "Release", "net9.0", "TempProject.exe");
                var dllPath = Path.Combine(tempDir, "bin", "Release", "net9.0", "TempProject.dll");
                
                var runPath = File.Exists(exePath) ? exePath : dllPath;
                var runResult = await RunProcessAsync("dotnet", $"\"{runPath}\"", tempDir, timeoutSeconds: 30);

                return new ExecutionResult
                {
                    Success = runResult.Success,
                    Output = runResult.Output,
                    ErrorMessage = runResult.Success ? null : "Execution failed or timed out."
                };
            }
            finally
            {
                // Clean up temporary directory
                try
                {
                    if (Directory.Exists(tempDir))
                    {
                        Directory.Delete(tempDir, true);
                    }
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
        }
        catch (Exception ex)
        {
            return new ExecutionResult
            {
                Success = false,
                Output = ex.Message,
                ErrorMessage = ex.Message
            };
        }
    }

    private async Task<(bool Success, string Output)> RunProcessAsync(
        string fileName, 
        string arguments, 
        string workingDirectory,
        int timeoutSeconds = 60)
    {
        var output = new StringBuilder();
        var error = new StringBuilder();

        try
        {
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    WorkingDirectory = workingDirectory,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    output.AppendLine(e.Data);
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    error.AppendLine(e.Data);
                }
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            var completed = await Task.Run(() => process.WaitForExit(timeoutSeconds * 1000));

            if (!completed)
            {
                try
                {
                    process.Kill(true);
                }
                catch
                {
                    // Ignore kill errors
                }
                return (false, "Execution timed out.");
            }

            var exitCode = process.ExitCode;
            var combinedOutput = output.ToString();
            
            if (exitCode != 0)
            {
                var errorOutput = error.ToString();
                if (!string.IsNullOrEmpty(errorOutput))
                {
                    combinedOutput += "\n" + errorOutput;
                }
            }

            return (exitCode == 0, combinedOutput);
        }
        catch (Exception ex)
        {
            return (false, $"Error running process: {ex.Message}");
        }
    }
}
