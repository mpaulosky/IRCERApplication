using IRCERApiDataManager.Library.Models;
using System;
using System.Collections.Generic;

namespace IRCERApiDataManager.Library.DataAccess
{
    public class MockUserData : IUserData
    {
        public List<UserModel> GetAllUsers()
        {
            var userData = new List<UserModel> { new UserModel { Id = "john.doe@test.com", FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@test.com", CreatedDate = DateTime.Now } };

            return userData;
        }

        public List<UserModel> GetUserById(string Id)
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                throw new System.ArgumentException("message", nameof(Id));
            }
            var userData = new List<UserModel> { new UserModel { Id = "john.doe@test.com", FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@test.com", CreatedDate = DateTime.Now } };

            return userData;
        }
    }
}