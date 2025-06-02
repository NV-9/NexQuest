using NexQuestGui.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace NexQuestGui.Views;
public partial class QuestList : Page
{
    private readonly QuestListViewModel _viewModel;
    public QuestList(QuestListViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        _viewModel = viewModel;
        Loaded += _viewModel.OnViewModelLoaded;
    }

    private void OnEditButtonClicked(object sender, RoutedEventArgs e)
    {
        _viewModel.ToggleEditMode();
    }

}
