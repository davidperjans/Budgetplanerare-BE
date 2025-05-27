//using Application.Auth.Commands;
//using Application.Auth.DTOs;
//using Application.Dto;
//using Domain.Moduls;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MediatR;

//namespace API.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class AuthControllerRegisterUser : ControllerBase
//{
//    private readonly IPasswordHasher<User> _passwordHasher;
//    private readonly IMediator _mediator;

//    public AuthControllerRegisterUser(IMediator mediator, IPasswordHasher<User> passwordHasher)
//    {
//        _mediator = mediator;
//        _passwordHasher = passwordHasher;
//    }

   

//    [HttpPost("login")]
//    public async Task<IActionResult> Login(LoginUserDto dto)
//    {
//        var result = await _mediator.Send(new LoginUserCommand(dto));

//        return result.IsSuccess
//            ? Ok(result.Value)
//            : BadRequest(result.Error);
//    }
    
    

//    [HttpPost("register")]
//    public async Task<IActionResult> Register(RegisterUserDto dto)
//    {
//        var result = await _mediator.Send(new RegisterUserCommand(dto));
        

//        return result.IsSuccess 
//            ? Ok(result.Value) : BadRequest(result.Error);
//    }
//}

