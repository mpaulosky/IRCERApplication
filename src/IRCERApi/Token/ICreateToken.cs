using System.Threading.Tasks;

namespace IRCERApi.Token
{
	public interface ICreateToken
	{
		Task<dynamic> GenerateToken(string username);
	}
}
