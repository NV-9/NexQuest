using NexQuest.Models;
using NexQuest.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace NexQuestGui.ViewModels;
public class QuestListViewModel : INotifyPropertyChanged
{
    private readonly IQuestService _questService;
    private bool _editModeActive;
    private string _editModeText = "Edit Mode: Off";

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Quest> Quests { get; set; }
    public bool EditModeActive
    {
        get => _editModeActive;
        set
        {
            if (_editModeActive != value)
            {
                _editModeActive = value;
                OnPropertyChanged();
            }
        }
    }

    public string EditModeText
    {
        get => _editModeText;
        set
        {
            if (_editModeText != value)
            {
                _editModeText = value;
                OnPropertyChanged();
            }
        }
    }


    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public QuestListViewModel(IQuestService questService)
    {
        _questService = questService;
        Quests = [];
        EditModeActive = false;
        EditModeText = "Edit Mode: Off";
    }

    public async void OnViewModelLoaded(object sender, RoutedEventArgs e)
    {
        Quests.Clear();
        var quests = await _questService.GetAllQuestsAsync();
        foreach (var quest in quests)
        {
            Quests.Add(quest);
        }
    }

    public void ToggleEditMode()
    {
        switch (EditModeActive)
        {
            case true:
                EditModeActive = false;
                EditModeText = "Edit Mode: Off";
                break;
            case false:
                EditModeActive = true;
                EditModeText = "Edit Mode: On";
                break;
        }
    }

    
}
