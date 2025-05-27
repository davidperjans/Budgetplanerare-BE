using Application.Dto;
using Application.Validators;
using FluentValidation.TestHelper;

namespace Tests.Validators;

[TestFixture]
public class RegisterUserDtoValidatorTests
{
    private RegisterUserDtoValidator _validator = null!;

    [SetUp]
    public void Setup()
    {
        _validator = new RegisterUserDtoValidator();
    }

    [Test]
    public void Should_Have_Error_When_Username_Is_Empty()
    {
        var model = new RegisterUserDto { UserName = "" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.UserName);
    }

    [Test]
    public void Should_Have_Error_When_Email_Is_Invalid()
    {
        var model = new RegisterUserDto { Email = "not-an-email" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Test]
    public void Should_Have_Error_When_Password_Is_Too_Short()
    {
        var model = new RegisterUserDto() { Password = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Test]
    public void Should_Not_Have_Errors_When_Model_Is_Valid()
    {
        var model = new RegisterUserDto()
        {
            UserName = "Mikael",
            Email = "mikael@example.com",
            Password = "securepass"
        };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}