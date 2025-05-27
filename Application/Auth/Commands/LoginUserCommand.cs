using Application.Dto;
using Domain.Shared.OperationalResult;
using MediatR;

namespace Application.Auth.Commands;

public record LoginUserCommand(LoginUserDto Dto) : IRequest<OperationResult<string>>;