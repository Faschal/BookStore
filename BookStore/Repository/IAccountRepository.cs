using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUser(SignUpUser userModel);
        Task<SignInResult> PasswordSignIn(SignIn signInModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePassword model);

        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);

    }
}