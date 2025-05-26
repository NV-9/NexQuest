using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace NexQuest.Models;
public class User
{
    public User () { }

    public User(string username)
    {
        UUID = Guid.NewGuid();
        Username = username;
    }

    public User(string username, string password)
    {
        UUID = Guid.NewGuid();
        Username = username;
        Password = password;
    }

    public int ID { get; set; }
    public Guid UUID { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

}
public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.ID);

        builder.Property(u => u.UUID).IsRequired();
        builder.Property(u => u.Username).IsRequired();
        builder.Property(u => u.Password).IsRequired();
    }
}
