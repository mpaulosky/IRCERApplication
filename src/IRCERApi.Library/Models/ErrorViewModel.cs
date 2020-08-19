using System.Diagnostics.CodeAnalysis;

namespace IRCERApi.Library.Models
{
	[ExcludeFromCodeCoverage]
	public class ErrorViewModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}
