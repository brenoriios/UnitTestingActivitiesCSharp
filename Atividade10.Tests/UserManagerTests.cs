using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Atividade10.Tests;
public class UserManagerTests
{
    private readonly IUserService _userService = Substitute.For<IUserService>();
    private readonly UserManager _sut;

    public UserManagerTests()
    {
        _sut = new UserManager(_userService);
    }

    [Fact]
    public void FetchUserInfo_ShouldReturnUser()
    {
        //Arrange
        var user = new User("Usuário 1", "email@example.com");

        _userService.GetUserInfo(1).ReturnsForAnyArgs(user);

        //Act
        var fetchedUser = _sut.FetchUserInfo(1);

        //Assert
        Assert.Equal(user.Name, fetchedUser.Name);
        Assert.Equal(user.Email, fetchedUser.Email);
    }

    [Fact]
    public void FetchUserInfo_InvalidId_ShouldReturnNull()
    {
        //Arrange
        _userService.GetUserInfo(Arg.Any<int>()).ReturnsNull();

        // Act
        var fetchedUser = _sut.FetchUserInfo(-1);

        // Assert
        Assert.Null(fetchedUser);
    }
}
