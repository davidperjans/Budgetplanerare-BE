//using Domain.Interfaces;
//using Domain.Moduls;
//using Microsoft.AspNetCore.Identity;


//namespace Infrastructure.Service;

//public class PasswordService : IPasswordService
//{
//    private readonly IPasswordHasher<User> _hasher = new PasswordHasher<User>();

//    public string HashPassword(User user, string password)
//    {
//        return _hasher.HashPassword(user, password);
//    }

//    public bool VerifyPassword(User user, string password)
//    {
//        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
//        return result == PasswordVerificationResult.Success;
//    }
//}