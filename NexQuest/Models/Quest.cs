using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace NexQuest.Models;
public class Quest
{
    public Quest() { }

    public Quest(string title, string description, QuestType type = QuestType.MainQuest, Quest? parent = null) 
    {
        Title = title;
        Description = description;
        Type = type;
        Parent = parent;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public int ID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public QuestType Type { get; set; }
    public Quest? Parent { get; set; }
    public Quest[] Children { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
public class QuestConfiguration : IEntityTypeConfiguration<Quest>
{
    public void Configure(EntityTypeBuilder<Quest> builder)
    {
        builder.HasKey(u => u.ID);

        builder.Property(u => u.Title).IsRequired();
        builder.Property(u => u.Description).IsRequired();
        builder.Property(u => u.Type).IsRequired();
        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.UpdatedAt).IsRequired();
    }
}

public enum QuestType
{
    MainQuest,
    SideQuest,
    SubQuest,
}