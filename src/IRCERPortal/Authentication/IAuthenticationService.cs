using System.Threading.Tasks;
using IRCERPortal.Models;

namespace IRCERPortal.Authentication
{
	public interface IAuthenticationService
	{
		Task<AuthenticatedUserModel> Login(AuthenticationUserModel userForAuthentication);
		Task Logout();
	}
}
