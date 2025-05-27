using Application.Auth.Commands;
using Domain.Interfaces;
using Domain.Moduls;
using Domain.Shared.OperationalResult;
using MediatR;

namespace Application.Auth.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, OperationResult<string>>
{
    private readonly IUserRepository _userRepo;
    private readonly IPasswordService _passwordService;

    public RegisterUserCommandHandler(IUserRepository userRepo, IPasswordService passwordService)
    {
        _userRepo = userRepo;
        _passwordService = passwordService;
    }

    public async Task<OperationResult<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        if (await _userRepo.ExistsByEmailAsync(dto.Email))
            return OperationResult<string>.Fail("E-postadressen används redan.");

        var user = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
            PasswordHash = _passwordService.HashPassword(new User(), dto.Password)
        };

        await _userRepo.AddAsync(user);
        return OperationResult<string>.Ok("Användare registrerad.");
    }
}