using IRCERApi.Library.Internal.DataAccess;
using IRCERApi.Library.Models;
using System.Collections.Generic;

namespace IRCERApi.Library.DataAccess
{
	public class UserData : IUserData
	{
		private readonly ISqlDataAccess _sql;

		public UserData(ISqlDataAccess sql)
		{
			_sql = sql;
		}

		public List<UserModel> GetUserById(string Id)
		{
			if (string.IsNullOrWhiteSpace(Id))
			{
				throw new System.ArgumentException("message", nameof(Id));
			}

			var output = _sql.LoadData<UserModel, dynamic>("dbo.spUser_Lookup", new { Id }, "IRCERData");

			return output;
		}

		public List<UserModel> GetAllUsers()
		{
			var output = _sql.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { }, "IRCERData");

			return output;
		}
	}
}
