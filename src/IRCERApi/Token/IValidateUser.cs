using System.Threading.Tasks;

namespace IRCERApi.Data
{
	public interface IValidateUser
	{
		Task<bool> IsValidUsernameAndPassword(string username, string password);
	}
}
