using System;
using System.Diagnostics.CodeAnalysis;

namespace IRCERApi.Library.Models
{
	[ExcludeFromCodeCoverage]
	public class UserModel
	{
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
