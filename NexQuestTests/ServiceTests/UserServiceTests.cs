using Moq;
using NexQuest.Models;
using NexQuest.Services;

namespace NexQuestTests.ServiceTests;

[TestClass]
public sealed class UserServiceTests
{

    private Mock<IUserService> mockUserService;

    [TestInitialize]
    public void Initialise()
    {
        mockUserService = new Mock<IUserService>();
    }

    [TestMethod]
    public async Task GivenUserServiceIsAvailableServiceShouldReturnFirstUser()
    {
        // Arrange
        var username = "testuser";
        var password = "password";
        mockUserService.Setup(s => s.GetUserAsync(username))
                       .ReturnsAsync(new User(username, password));

        // Act
        var result = mockUserService.Object.GetUserAsync(username).Result;

        // Assert
        Assert.AreEqual(username, result.Username);
    }

}
