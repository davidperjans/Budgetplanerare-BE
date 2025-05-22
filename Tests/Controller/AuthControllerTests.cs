using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Identity;
using API.Controllers;
using Domain.Moduls;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Controller;

[TestFixture]
public class AuthControllerTests
{
    private AppDbContext _context = null!;
    private AuthController _controller = null!;
    private Mock<IPasswordHasher<User>> _passwordHasherMock = null!;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // 🆕 Unik databas för varje test
            .Options;

        _context = new AppDbContext(options);

        _passwordHasherMock = new Mock<IPasswordHasher<User>>();
        _controller = new AuthController(_context, _passwordHasherMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task Register_Should_Return_BadRequest_If_Email_Exists()
    {
        var user = new User { Email = "test@example.com" };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var dto = new UserDto
        {
            Email = "test@example.com",
            UserName = "Test",
            Password = "password"
        };

        var result = await _controller.Register(dto);

        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task Register_Should_Return_Ok_When_Successful()
    {
        var dto = new UserDto
        {
            Email = "new@example.com",
            UserName = "NewUser",
            Password = "password"
        };

        _passwordHasherMock
            .Setup(ph => ph.HashPassword(It.IsAny<User>(), dto.Password))
            .Returns("hashed");

        var result = await _controller.Register(dto);

        Assert.IsInstanceOf<OkObjectResult>(result);
        Assert.That(_context.Users.Count(u => u.Email == "new@example.com"), Is.EqualTo(1));
    }
}
