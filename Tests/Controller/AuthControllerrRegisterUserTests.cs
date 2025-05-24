using Moq;
using NUnit.Framework;
using API.Controllers;
using Application.Auth.Commands;
using Application.Auth.DTOs;
using Domain.Moduls;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API.Controllers;

namespace Tests.Controller;

[TestFixture]
public class AuthControllerTests
{
    private Mock<IMediator> _mediatorMock;
    private Mock<IPasswordHasher<User>> _passwordHasherMock;
    private AuthController _controller;


    [SetUp]
    public void Setup()
    {
       _mediatorMock = new Mock<IMediator>();
       _controllerRegisterUser = new AuthController(_mediatorMock.Object, _passwordHasherMock.Object);
         _passwordHasherMock = new Mock<IPasswordHasher<User>>();
    }
    

    [Test]
    public async Task Register_Should_Return_BadRequest_If_Email_Exists()
    {

        var dto = new RegisterUserDto
        {
            Email = "test@example.com",
            UserName = "Test",
            Password = "password"
        };
        
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), default))
            .ReturnsAsync(OperationResult<string>.Fail("E-postadressen används redan."));

        var result = await _controllerRegisterUser.Register(dto);

        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task Register_Should_Return_Ok_When_Successful()
    {
        var dto = new RegisterUserDto
        {
            Email = "new@example.com",
            UserName = "NewUser",
            Password = "password"
        };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), default))
            .ReturnsAsync(OperationResult<string>.Ok("Användare registrerad."));

        var result = await _controllerRegisterUser.Register(dto);

        Assert.IsInstanceOf<OkObjectResult>(result);
    }
}
