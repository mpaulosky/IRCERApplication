using IRCERDataManager.Library.Models;
using System.Collections.Generic;

namespace IRCERDataManager.Library.DataAccess
{
    public interface IUserData
    {
        List<UserModel> GetUserById(string Id);
    }
}