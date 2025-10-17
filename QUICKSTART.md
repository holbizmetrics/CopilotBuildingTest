# Quick Start Guide - Vibe Coding

Get up and running with Vibe Coding in 5 minutes!

## Prerequisites
- Windows 10 or 11
- .NET 9.0 SDK ([Download here](https://dotnet.microsoft.com/download/dotnet/9.0))

## Installation

### Option 1: Clone from GitHub
```bash
git clone https://github.com/holbizmetrics/CopilotBuildingTest.git
cd CopilotBuildingTest
```

### Option 2: Download ZIP
1. Download the repository as ZIP
2. Extract to your preferred location
3. Open a terminal in the extracted folder

## Build and Run

### Quick Start (Command Line)
```bash
# Restore dependencies
dotnet restore VibeCoding.sln

# Build the solution
dotnet build VibeCoding.sln

# Run the application
dotnet run --project src/VibeCoding.UI/VibeCoding.UI.csproj
```

### Using Visual Studio 2022
1. Open `VibeCoding.sln`
2. Press **F5** to run

### Using Visual Studio Code
1. Open the project folder
2. Install "C# Dev Kit" extension
3. Press **F5** to run

## First Steps

### 1. Welcome Screen
When you launch Vibe Coding, you'll see:
- A code editor with sample C# code
- A toolbar with Run, Clear Output, and New Tab buttons
- An output console at the bottom

### 2. Running Your First Code
1. The editor already contains sample code
2. Click the green **Run** button
3. See the output in the console below

### 3. Writing New Code
Replace the sample code with your own:
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, Vibe Coding!");
        
        // Try some loops
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Count: {i}");
        }
    }
}
```

### 4. Working with Multiple Tabs
- Click **New Tab** to create a new editor
- Click the **×** on any tab to close it
- Switch between tabs by clicking on them

### 5. Managing Output
- Click **Clear Output** to clear the console
- Output shows both successful results and errors
- Errors are displayed with detailed messages

## Example Code Snippets

### Hello World
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
    }
}
```

### Array Processing
```csharp
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        int sum = numbers.Sum();
        Console.WriteLine($"Sum: {sum}");
    }
}
```

### File Operations
```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string content = "Hello from Vibe Coding!";
        string path = Path.Combine(Path.GetTempPath(), "test.txt");
        File.WriteAllText(path, content);
        
        string readContent = File.ReadAllText(path);
        Console.WriteLine(readContent);
        
        File.Delete(path);
    }
}
```

### Async/Await
```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await Task.Delay(1000);
        Console.WriteLine("Delayed message!");
        
        var result = await GetMessageAsync();
        Console.WriteLine(result);
    }
    
    static async Task<string> GetMessageAsync()
    {
        await Task.Delay(500);
        return "Async operation complete!";
    }
}
```

## Tips and Tricks

### Keyboard Shortcuts
- **Ctrl+A** - Select all
- **Ctrl+C** - Copy
- **Ctrl+V** - Paste
- **Ctrl+Z** - Undo
- **Ctrl+Y** - Redo

### Code Editor Features
- **Line Numbers** - Automatically displayed
- **Syntax Highlighting** - C# keywords are highlighted
- **Scrolling** - Use mouse wheel or scrollbar

### Best Practices
1. Always include `using System;` for console operations
2. Ensure your code has a `Main()` method
3. Use meaningful variable names
4. Check the output console for errors
5. Create new tabs for different experiments

## Troubleshooting

### Application won't start
- Ensure .NET 9.0 SDK is installed
- Check you're running on Windows
- Try running from command line to see errors

### Code won't compile
- Check for syntax errors
- Ensure you have a `Main()` method
- Look at the error messages in the output console

### Code compiles but doesn't run
- Check for runtime exceptions
- Ensure your logic is correct
- Look for null reference errors

### Output is empty
- Make sure you're using `Console.WriteLine()`
- Check that your code actually executes
- Verify the output console is visible

## Getting Help

### Documentation
- **README.md** - Full documentation
- **IMPLEMENTATION.md** - Technical details
- **This file** - Quick start guide

### Common Issues
1. **"dotnet not found"** - Install .NET 9.0 SDK
2. **"Build failed"** - Check your code syntax
3. **"Execution timed out"** - Your code took longer than 30 seconds

## What's Next?

Now that you're up and running:
1. Experiment with different C# features
2. Try working with multiple tabs
3. Explore LINQ and async/await
4. Build small console applications
5. Have fun coding! 🚀

---

**Need more help?** Check the full README.md for detailed documentation.

**Want to contribute?** See IMPLEMENTATION.md for technical details.

**Found a bug?** Please report it on GitHub!
