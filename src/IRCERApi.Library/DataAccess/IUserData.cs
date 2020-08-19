using IRCERApi.Library.Models;
using System.Collections.Generic;

namespace IRCERApi.Library.DataAccess
{
	public interface IUserData
	{
		List<UserModel> GetUserById(string Id);

		List<UserModel> GetAllUsers();
	}
}
