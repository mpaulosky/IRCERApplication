using IRCERApi.Library.Models;
using System;
using System.Collections.Generic;

namespace IRCERApi.Library.DataAccess
{
	public static class MockUserData
	{
		public static List<UserModel> User()
		{
			return new List<UserModel>
						{
								new UserModel
								{
										Id = "john.doe@test.com",
										FirstName = "John",
										LastName = "Doe",
										EmailAddress = "john.doe@test.com",
										CreatedDate = DateTime.Now
								}
						};
		}

		public static List<UserModel> Users()
		{
			return new List<UserModel>
						{
								new UserModel
								{
										Id = "john.doe@test.com",
										FirstName = "John",
										LastName = "Doe",
										EmailAddress = "john.doe@test.com",
										CreatedDate = DateTime.Now
								},
								new UserModel
								{
										Id = "jane.doe@test.com",
										FirstName = "Jane",
										LastName = "Doe",
										EmailAddress = "jane.doe@test.com",
										CreatedDate = DateTime.Now
								}
						};
		}
	}
}
