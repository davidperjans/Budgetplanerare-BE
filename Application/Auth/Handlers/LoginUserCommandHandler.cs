using Application.Auth.Commands;
using Application.Dto;
using Domain.Shared.OperationalResult;
using MediatR;
using Domain.Interfaces;

namespace Application.Auth.Handlers;
//TODO:  Generera JWT i LoginUserCommandHandler (istället för dummy-token)
//TODO:  Implementera lösenordshantering i PasswordService
public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, OperationResult<string>>
{
    private readonly IUserRepository _userRepo;
    private readonly IPasswordService _passwordService;
    
    private string InvalidCredentialsMessage => "Ogiltiga inloggningsuppgifter.";
    
    public LoginUserCommandHandler(IUserRepository userRepo, IPasswordService passwordService)
    {
        _userRepo = userRepo;
        _passwordService = passwordService;
    }
    
    public async Task<OperationResult<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var user = await _userRepo.GetByEmailAsync(dto.Email);
        if (user == null || !_passwordService.VerifyPassword(user, dto.Password))
        {
            return OperationResult<string>.Fail(InvalidCredentialsMessage);
        }

        // Here you would typically generate a JWT token or similar
        // For simplicity, we return a success message
        return OperationResult<string>.Ok("Inloggning lyckades.");
    }
}