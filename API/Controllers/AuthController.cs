using Application.Dto;
using Domain.Moduls;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Database;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthController(AppDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        
        if(user == null)
            return BadRequest("Ogiltig e-postadress eller lösenord.");
        
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        
        if (result == PasswordVerificationResult.Failed)
            return BadRequest("Ogiltig e-postadress eller lösenord.");
        
        return Ok("Inloggning lyckades. Token kommer här snart...");


    }
    
    

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDto dto)
    {
        if (_context.Users.Any(u => u.Email == dto.Email))
            return BadRequest("E-postadressen används redan.");

        var user = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
            PasswordHash = "" // tillfälligt, sätts nedan
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("Användare registrerad.");
    }
}

