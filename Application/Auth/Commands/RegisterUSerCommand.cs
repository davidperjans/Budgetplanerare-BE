using Application.Dto;
using Domain.Shared.OperationalResult;
using MediatR;

namespace Application.Auth.Commands;

public record RegisterUserCommand(RegisterUserDto Dto) : IRequest<OperationResult<string>>;
