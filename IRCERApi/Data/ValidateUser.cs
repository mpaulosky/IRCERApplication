using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IRCERApi.Data
{
    public class ValidateUser : IValidateUser
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ValidateUser(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> IsValidUsernameAndPassword(string username, string password)
        {
            var user = await _userManager.FindByEmailAsync(username);
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}