﻿using IRCERDataManager.Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestHelpers
{
    /// <summary>
    /// <![CDATA[https://github.com/dotnet/aspnetcore/blob/master/src/Identity/test/Shared/MockHelpers.cs]]>
    /// </summary>
    public static class MockHelpers
    {
        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
            return mgr;
        }

        public static Mock<RoleManager<TRole>> MockRoleManager<TRole>(IRoleStore<TRole> store = null) where TRole : class
        {
            store = store ?? new Mock<IRoleStore<TRole>>().Object;
            var roles = new List<IRoleValidator<TRole>>();
            roles.Add(new RoleValidator<TRole>());
            return new Mock<RoleManager<TRole>>(store, roles, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null);
        }

        public static UserManager<TUser> TestUserManager<TUser>(IUserStore<TUser> store = null) where TUser : class
        {
            store = store ?? new Mock<IUserStore<TUser>>().Object;
            var options = new Mock<IOptions<IdentityOptions>>();
            var idOptions = new IdentityOptions();
            idOptions.Lockout.AllowedForNewUsers = false;
            options.Setup(o => o.Value).Returns(idOptions);
            var userValidators = new List<IUserValidator<TUser>>();
            var validator = new Mock<IUserValidator<TUser>>();
            userValidators.Add(validator.Object);
            var pwdValidators = new List<PasswordValidator<TUser>>();
            pwdValidators.Add(new PasswordValidator<TUser>());
            var userManager = new UserManager<TUser>(store, options.Object, new PasswordHasher<TUser>(),
                userValidators, pwdValidators, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null,
                new Mock<ILogger<UserManager<TUser>>>().Object);
            validator.Setup(v => v.ValidateAsync(userManager, It.IsAny<TUser>()))
                .Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
            return userManager;
        }

        public static RoleManager<TRole> TestRoleManager<TRole>(IRoleStore<TRole> store = null) where TRole : class
        {
            store = store ?? new Mock<IRoleStore<TRole>>().Object;
            var roles = new List<IRoleValidator<TRole>>();
            roles.Add(new RoleValidator<TRole>());
            return new RoleManager<TRole>(store, roles,
                new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(),
                null);
        }

        public static IdentityUser GetIdentityUser()
        {
            return new IdentityUser
            {
                Id = "123",
                UserName = "test@test.com",
                PasswordHash = "test",
                Email = "test@test.com"
            };
        }

        public static List<UserModel> GetSamplePeople()
        {
            var persons = new List<UserModel>
            {
                new UserModel
                {
                    Id ="Tim.Corey@corey.org",
                    FirstName = "Tim",
                    LastName = "Corey",
                    EmailAddress = "Tim.Corey@corey.org",
                },
                new UserModel
                {
                    Id ="Charity.Corey@corey.org",
                    FirstName = "Charity",
                    LastName = "Corey",
                    EmailAddress = "Charity.Corey@corey.org",
                },
                new UserModel
                {
                    Id ="Jon.Corey@corey.org",
                    FirstName = "Jon",
                    LastName = "Corey",
                    EmailAddress = "Jon.Corey@corey.org",
                },
                new UserModel
                {
                    Id ="Chris.Corey@corey.org",
                    FirstName = "Chris",
                    LastName = "Corey",
                    EmailAddress = "Chris.Corey@corey.org",
                }
            };

            return persons;
        }

        public static List<IdentityUser> GetSampleIdentityUsers()
        {
            var persons = new List<IdentityUser>
            {
                new IdentityUser
                {
                    Id ="Tim.Corey@corey.org",
                    UserName = "Tim.Corey@corey.org",
                    Email = "Tim.Corey@corey.org",
                },
                new IdentityUser
                {
                    Id ="Charity.Corey@corey.org",
                    UserName = "Charity.Corey@corey.org",
                    Email = "Charity.Corey@corey.org",
                },
                new IdentityUser
                {
                    Id ="Jon.Corey@corey.org",
                    UserName = "Jon.Corey@corey.org",
                    Email = "Jon.Corey@corey.org",
                },
                new IdentityUser
                {
                    Id ="Chris.Corey@corey.org",
                    UserName = "Chris.Corey@corey.org",
                    Email = "Chris.Corey@corey.org",
                }
            };

            return persons;
        }

        public static async Task<IList<string>> GetSampleIdentityRoles()
        {
            var roles = new List<string> { "Admin", "User" };

            return roles;
        }
    }
}