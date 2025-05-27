using NexQuest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexQuestGui.ViewModels;

public class QuestListViewModel
{
    public ObservableCollection<Quest> Quests { get; set; }

    public QuestListViewModel()
    {
        Quests =
        [
            new Quest("Find the Sword", "Retrieve the legendary blade from the cave.", type: QuestType.MainQuest),
            new Quest("Rescue the Princess", "Save the princess from the tower.", type: QuestType.MainQuest),
            new Quest("Defeat the Dragon", "Slay the dragon in the eastern mountains.", type: QuestType.SideQuest)
        ];
    }
}
