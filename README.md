# Vibe Coding

A modern WPF desktop application for writing and executing C# code with a clean, user-friendly interface.

## Features

- 📝 **Tabbed Code Editor** - Work with multiple code files simultaneously using a tabbed interface
- 🎨 **Syntax Highlighting** - C# code syntax highlighting powered by AvalonEdit
- ▶️ **Run Code** - Compile and execute C# code directly from the editor
- 🖥️ **Embedded Console** - View output and errors in an integrated console window
- 🧹 **Clear Output** - Easily clear the console output
- 🏗️ **MVVM Architecture** - Built with CommunityToolkit.Mvvm for clean, maintainable code
- ✅ **Well-Tested** - Comprehensive unit tests for core logic

## Project Structure

```
VibeCoding/
├── src/
│   ├── VibeCoding.UI/          # WPF application (Views, ViewModels)
│   └── VibeCoding.Core/        # Core logic (Services, Models)
├── tests/
│   └── VibeCoding.Tests/       # Unit tests
└── VibeCoding.sln              # Solution file
```

## Requirements

- **.NET 9.0 SDK** or later
- **Windows** operating system (for running the WPF application)
- **Visual Studio 2022** or **Visual Studio Code** (recommended for development)

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/holbizmetrics/CopilotBuildingTest.git
cd CopilotBuildingTest
```

### 2. Restore Dependencies

```bash
dotnet restore VibeCoding.sln
```

### 3. Build the Solution

```bash
dotnet build VibeCoding.sln
```

### 4. Run Tests

```bash
dotnet test VibeCoding.sln
```

## Running the Application

### From Command Line

```bash
dotnet run --project src/VibeCoding.UI/VibeCoding.UI.csproj
```

### From Visual Studio

1. Open `VibeCoding.sln` in Visual Studio 2022
2. Set `VibeCoding.UI` as the startup project
3. Press **F5** or click the **Start** button

### From Visual Studio Code

1. Open the project folder in VS Code
2. Install the C# Dev Kit extension if not already installed
3. Press **F5** to debug or **Ctrl+F5** to run without debugging

## Usage Guide

### Creating and Managing Tabs

1. **New Tab** - Click the "New Tab" button in the toolbar to create a new editor tab
2. **Switch Tabs** - Click on any tab to switch to that editor
3. **Close Tab** - Click the "×" button on any tab to close it (at least one tab must remain open)

### Writing Code

1. Write or paste your C# code in the editor
2. The editor provides:
   - Syntax highlighting for C# keywords and syntax
   - Line numbers for easy navigation
   - Consolas font for better readability

### Running Code

1. Click the **Run** button in the toolbar
2. Your code will be compiled and executed
3. Results will appear in the Output Console at the bottom
4. Both standard output and errors will be displayed

### Clearing Output

- Click the **Clear Output** button to clear the console output

### Example Code

The application comes with a default example:

```csharp
// Welcome to Vibe Coding!
// Write your C# code here and click Run to execute it.

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello from Vibe Coding!");
        
        // Your code here
    }
}
```

## Architecture

### MVVM Pattern

The application follows the Model-View-ViewModel (MVVM) pattern:

- **Views** (`VibeCoding.UI/Views/`) - XAML-based user interface
- **ViewModels** (`VibeCoding.UI/ViewModels/`) - Presentation logic and commands
- **Models** (`VibeCoding.Core/Models/`) - Data structures
- **Services** (`VibeCoding.Core/Services/`) - Business logic

### Key Components

#### UI Layer (`VibeCoding.UI`)
- **MainWindow.xaml** - Main application window
- **MainViewModel.cs** - Manages tabs, commands, and output
- **EditorTabViewModel.cs** - Represents individual editor tabs

#### Core Layer (`VibeCoding.Core`)
- **CodeExecutionService.cs** - Handles code compilation and execution
- **ICodeExecutionService.cs** - Service interface for testability
- **ExecutionResult.cs** - Represents execution results

#### Tests Layer (`VibeCoding.Tests`)
- **CodeExecutionServiceTests.cs** - Unit tests for code execution logic

## Dependencies

### UI Project
- **AvalonEdit** (6.3.0.90) - Advanced text editor with syntax highlighting
- **CommunityToolkit.Mvvm** (8.3.2) - MVVM toolkit for simplified development

### Tests Project
- **xUnit** - Unit testing framework
- **xUnit Runner** - Test runner for Visual Studio and CLI

## Building for Release

To build the application for release:

```bash
dotnet build VibeCoding.sln --configuration Release
```

The compiled application will be in:
```
src/VibeCoding.UI/bin/Release/net9.0-windows/
```

## Troubleshooting

### Build Issues

**Issue**: Build fails with Windows targeting error
- **Solution**: Ensure you're building on Windows or have `EnableWindowsTargeting` set to `true` in the project file

**Issue**: Missing dependencies
- **Solution**: Run `dotnet restore VibeCoding.sln`

### Runtime Issues

**Issue**: Code doesn't execute
- **Solution**: Ensure your code has a valid entry point (`Main` method)

**Issue**: Compilation errors
- **Solution**: Check the Output Console for detailed error messages

## Contributing

Contributions are welcome! Please feel free to submit pull requests or open issues.

## License

This project is provided as-is for educational and development purposes.

## Future Enhancements

Potential features for future versions:
- Support for multiple programming languages
- Code templates and snippets
- File save/load functionality
- Customizable themes
- Intellisense/code completion
- Debugging support
- NuGet package management

---

**Enjoy coding with Vibe Coding!** 🚀