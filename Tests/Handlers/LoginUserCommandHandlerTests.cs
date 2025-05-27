using Application.Auth.Commands;
using Application.Dto;
using Application.Auth.Handlers;
using Domain.Interfaces;
using Domain.Moduls;
using Moq;
using NUnit.Framework;

namespace Tests.Handlers;

[TestFixture]
public class LoginUserCommandHandlerTests
{
    private Mock<IUserRepository> _userRepoMock = null!;
    private Mock<IPasswordService> _passwordServiceMock = null!;
    private LoginUserCommandHandler _handler = null!;

    [SetUp]
    public void Setup()
    {
        _userRepoMock = new Mock<IUserRepository>();
        _passwordServiceMock = new Mock<IPasswordService>();
        _handler = new LoginUserCommandHandler(_userRepoMock.Object, _passwordServiceMock.Object);
    }

    [Test]
    public async Task Handle_Should_Return_Fail_If_User_Not_Found()
    {
        var dto = new LoginUserDto
        {
            Email = "notfound@example.com",
            Password = "wrongpass"
        };

        _userRepoMock.Setup(r => r.GetByEmailAsync(dto.Email)).ReturnsAsync((User?)null);

        var result = await _handler.Handle(new LoginUserCommand(dto), default);

        Assert.IsFalse(result.IsSuccess);
        Assert.That(result.Error, Is.EqualTo("Ogiltiga inloggningsuppgifter."));
    }

    [Test]
    public async Task Handle_Should_Return_Fail_If_Password_Is_Invalid()
    {
        var dto = new LoginUserDto
        {
            Email = "user@example.com",
            Password = "wrongpass"
        };

        var user = new User { Email = dto.Email, PasswordHash = "hashed" };

        _userRepoMock.Setup(r => r.GetByEmailAsync(dto.Email)).ReturnsAsync(user);
        _passwordServiceMock.Setup(p => p.VerifyPassword(user, dto.Password)).Returns(false);

        var result = await _handler.Handle(new LoginUserCommand(dto), default);

        Assert.IsFalse(result.IsSuccess);
        Assert.That(result.Error, Is.EqualTo("Ogiltiga inloggningsuppgifter."));
    }

    [Test]
    public async Task Handle_Should_Return_Ok_If_Credentials_Are_Valid()
    {
        var dto = new LoginUserDto
        {
            Email = "user@example.com",
            Password = "correctpass"
        };

        var user = new User { Email = dto.Email, PasswordHash = "hashed" };

        _userRepoMock.Setup(r => r.GetByEmailAsync(dto.Email)).ReturnsAsync(user);
        _passwordServiceMock.Setup(p => p.VerifyPassword(user, dto.Password)).Returns(true);

        var result = await _handler.Handle(new LoginUserCommand(dto), default);

        Assert.IsTrue(result.IsSuccess);
        Assert.That(result.Value, Is.EqualTo("Inloggning lyckades."));
    }
}

