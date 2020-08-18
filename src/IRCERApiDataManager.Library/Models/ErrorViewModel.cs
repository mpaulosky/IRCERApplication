using System.Diagnostics.CodeAnalysis;

namespace IRCERApiDataManager.Library.Models
{
	[ExcludeFromCodeCoverage]
	public class ErrorViewModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}
