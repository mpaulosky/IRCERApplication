using IRCERApiDataManager.Library.Models;
using System.Collections.Generic;

namespace IRCERApiDataManager.Library.DataAccess
{
	public interface IUserData
	{
		List<UserModel> GetUserById(string Id);

		List<UserModel> GetAllUsers();
	}
}
