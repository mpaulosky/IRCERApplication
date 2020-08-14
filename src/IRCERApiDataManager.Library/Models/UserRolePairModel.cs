using System.Diagnostics.CodeAnalysis;

namespace IRCERApiDataManager.Library.Models
{
    [ExcludeFromCodeCoverage]
    public class UserRolePairModel
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}