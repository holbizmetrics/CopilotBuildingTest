using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VibeCoding.Core.Services;

namespace VibeCoding.UI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ICodeExecutionService _codeExecutionService;

    [ObservableProperty]
    private ObservableCollection<EditorTabViewModel> editorTabs = new();

    [ObservableProperty]
    private EditorTabViewModel? selectedTab;

    [ObservableProperty]
    private string outputText = string.Empty;

    public MainViewModel() : this(new CodeExecutionService())
    {
    }

    public MainViewModel(ICodeExecutionService codeExecutionService)
    {
        _codeExecutionService = codeExecutionService;
        
        // Create initial tab
        var initialTab = new EditorTabViewModel();
        EditorTabs.Add(initialTab);
        SelectedTab = initialTab;
    }

    [RelayCommand]
    private async Task RunAsync()
    {
        if (SelectedTab == null)
            return;

        OutputText = "Compiling and running...\n";

        var code = SelectedTab.Document.Text;
        var result = await _codeExecutionService.ExecuteCodeAsync(code);

        OutputText = result.Success 
            ? $"=== Execution Result ===\n{result.Output}" 
            : $"=== Error ===\n{result.Output}";
    }

    [RelayCommand]
    private void ClearOutput()
    {
        OutputText = string.Empty;
    }

    [RelayCommand]
    private void NewTab()
    {
        var newTab = new EditorTabViewModel();
        EditorTabs.Add(newTab);
        SelectedTab = newTab;
    }

    [RelayCommand]
    private void CloseTab(EditorTabViewModel tab)
    {
        if (EditorTabs.Count <= 1)
            return; // Keep at least one tab

        var index = EditorTabs.IndexOf(tab);
        EditorTabs.Remove(tab);

        // Select adjacent tab
        if (EditorTabs.Count > 0)
        {
            SelectedTab = index > 0 
                ? EditorTabs[index - 1] 
                : EditorTabs[0];
        }
    }
}
