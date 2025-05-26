using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NexQuest.Database;
using NexQuest.Models;
using NexQuest.Services;

namespace NexQuestTests.ModelTests;

[TestClass]
public sealed class UserTests
{
    private static ServiceProvider serviceProvider = null!;
    private IServiceScope scope = null!;
    private IUserService userService = null!;

    [TestInitialize]
    public void TestInit()
    {
        var dbName = Guid.NewGuid().ToString();

        var services = new ServiceCollection();
        services.AddDbContext<NexQuestDbContext>(options =>
                options.UseInMemoryDatabase(dbName));
        services.AddScoped<IUserService, UserService>();

        serviceProvider = services.BuildServiceProvider();
        scope = serviceProvider.CreateScope();
        userService = scope.ServiceProvider.GetRequiredService<IUserService>(); 
    }

    [TestCleanup]
    public void Cleanup()
    {
        var context = scope.ServiceProvider.GetRequiredService<NexQuestDbContext>();
        context.Database.EnsureDeleted();
        scope.Dispose();
    }

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

    [TestMethod]
    public async Task GivenUserClassIsAvailableUserShouldBeCreated()
    {
        // Arrange
        var username = "testuser";
        var password = "password";
        var context = scope.ServiceProvider.GetRequiredService<NexQuestDbContext>();

        // Act
        await userService.AddUserAsync(username, password);
        var user = context.Users.First();

        // Assert
        Assert.IsNotNull(user);
        Assert.AreEqual(username, user!.Username);
    }


    [TestMethod]
    public async Task GivenUserIsCreatedUserShouldBeFetchedByUsername()
    {
        // Arrange
        var username = "testuser";
        var password = "password";
        await userService.AddUserAsync(username, password);

        // Act
        var user = await userService.GetUserAsync(username);

        // Assert
        Assert.IsNotNull(user);
        Assert.AreEqual(username, user!.Username);
    }

    [TestMethod]
    public async Task GivenUserIsCreatedUserShouldBeFetchedById()
    {
        // Arrange
        var userId = 1;
        var username = "testuser";
        var password = "password";
        await userService.AddUserAsync(username, password);

        // Act
        var user = await userService.GetUserAsync(username);

        // Assert
        Assert.IsNotNull(user);
        Assert.AreEqual(userId, user!.ID);
    }

    [TestMethod]
    public async Task GivenUserIsCreatedUserShouldBeFetchedByGuid()
    {
        // Arrange
        var username = "testuser";
        var password = "password";
        var testUser = await userService.GetOrAddUserAsync(username, password);

        // Act
        var user = await userService.GetUserAsync(username);

        // Assert
        Assert.IsNotNull(user);
        Assert.AreEqual(testUser!.UUID, user!.UUID);
    }
}
