using NexQuest.Models;

namespace NexQuestTests.ModelTests;

[TestClass]
public sealed class UserTests
{
    [TestMethod]
    public void GivenUserClassIsAvailableClassShouldNotThrow()
    {
        // Arrange
        var user = new User();

        // Act 

        // Assert
        Assert.IsNotNull(user);
    }

    [TestMethod]
    public void GivenUserClassIsAvailableClassShouldBeConstructedWithVariableParams()
    {
        // Arrange
        var userWithNoParams = new User();
        var userWithUsername = new User("Test User");
        var userWithPassword = new User("Test User", "Test Password");

        // Act 
        
        // Assert
        Assert.IsNotNull(userWithNoParams);
        Assert.IsNotNull(userWithUsername);
        Assert.IsNotNull(userWithPassword);
    }
}
