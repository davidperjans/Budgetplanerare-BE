﻿using Domain.Moduls;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<bool> ExistsByEmailAsync(string email);
    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);

}