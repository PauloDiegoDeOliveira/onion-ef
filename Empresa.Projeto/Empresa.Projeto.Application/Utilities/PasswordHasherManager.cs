using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Utilities
{
    public class PasswordHasherManager
    {
        public HashedPassword ConvertPasswordToHash(string password)
        {
            HashedPassword hashedPassword = new HashedPassword();
            PasswordHasher<HashedPassword> passwordHasher = new PasswordHasher<HashedPassword>();
            hashedPassword.ChangePassword(passwordHasher.HashPassword(hashedPassword, password));
            return hashedPassword;
        }

        public async Task<bool> ValidatePassword(string hash, string password)
        {
            HashedPassword hashedPassword = new HashedPassword();
            PasswordHasher<HashedPassword> passwordHasher = new PasswordHasher<HashedPassword>();
            var status = passwordHasher.VerifyHashedPassword(hashedPassword, hash, password);
            await Task.CompletedTask;

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    return true;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
