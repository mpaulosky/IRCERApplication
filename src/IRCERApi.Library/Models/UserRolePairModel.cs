using System.Diagnostics.CodeAnalysis;

namespace IRCERApi.Library.Models
{
	[ExcludeFromCodeCoverage]
	public class UserRolePairModel
	{
		public string UserId { get; set; }
		public string RoleName { get; set; }
	}
}
