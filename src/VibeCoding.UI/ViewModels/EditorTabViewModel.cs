using CommunityToolkit.Mvvm.ComponentModel;
using ICSharpCode.AvalonEdit.Document;

namespace VibeCoding.UI.ViewModels;

public partial class EditorTabViewModel : ObservableObject
{
    [ObservableProperty]
    private string title = "Untitled";

    [ObservableProperty]
    private TextDocument document = new();

    private static int tabCounter = 1;

    public EditorTabViewModel()
    {
        Title = $"Tab {tabCounter++}";
        Document.Text = @"// Welcome to Vibe Coding!
// Write your C# code here and click Run to execute it.

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(""Hello from Vibe Coding!"");
        
        // Your code here
    }
}";
    }
}
