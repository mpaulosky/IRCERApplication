using IRCERApi.Controllers.UnitTests;
using IRCERApiDataManager.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace TestHelpers
{
	/// <summary>
	/// <![CDATA[https://github.com/dotnet/aspnetcore/blob/master/src/Identity/test/Shared/MockHelpers.cs]]>
	/// </summary>
	public static class MockHelpers
	{
		public static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
		{
			var elementsAsQueryable = elements.AsQueryable();
			var dbSetMock = new Mock<DbSet<T>>();

			dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
			dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
			dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
			dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

			return dbSetMock;
		}

		public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
		{
			var store = new Mock<IUserStore<TUser>>();
			var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
			mgr.Object.UserValidators.Add(new UserValidator<TUser>());
			mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
			return mgr;
		}

		//public static Mock<RoleManager<TRole>> MockRoleManager<TRole>(IRoleStore<TRole> store = null) where TRole : class
		//{
		//    store = store ?? new Mock<IRoleStore<TRole>>().Object;
		//    var roles = new List<IRoleValidator<TRole>>();
		//    roles.Add(new RoleValidator<TRole>());
		//    return new Mock<RoleManager<TRole>>(store, roles, new UpperInvariantLookupNormalizer(),
		//        new IdentityErrorDescriber(), null);
		//}

		//public static UserManager<TUser> TestUserManager<TUser>(IUserStore<TUser> store = null) where TUser : class
		//{
		//    store = store ?? new Mock<IUserStore<TUser>>().Object;
		//    var options = new Mock<IOptions<IdentityOptions>>();
		//    var idOptions = new IdentityOptions();
		//    idOptions.Lockout.AllowedForNewUsers = false;
		//    options.Setup(o => o.Value).Returns(idOptions);
		//    var userValidators = new List<IUserValidator<TUser>>();
		//    var validator = new Mock<IUserValidator<TUser>>();
		//    userValidators.Add(validator.Object);
		//    var pwdValidators = new List<PasswordValidator<TUser>>();
		//    pwdValidators.Add(new PasswordValidator<TUser>());
		//    var userManager = new UserManager<TUser>(store, options.Object, new PasswordHasher<TUser>(),
		//        userValidators, pwdValidators, new UpperInvariantLookupNormalizer(),
		//        new IdentityErrorDescriber(), null,
		//        new Mock<ILogger<UserManager<TUser>>>().Object);
		//    validator.Setup(v => v.ValidateAsync(userManager, It.IsAny<TUser>()))
		//        .Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
		//    return userManager;
		//}

		//public static RoleManager<TRole> TestRoleManager<TRole>(IRoleStore<TRole> store = null) where TRole : class
		//{
		//    store = store ?? new Mock<IRoleStore<TRole>>().Object;
		//    var roles = new List<IRoleValidator<TRole>>();
		//    roles.Add(new RoleValidator<TRole>());
		//    return new RoleManager<TRole>(store, roles,
		//        new UpperInvariantLookupNormalizer(),
		//        new IdentityErrorDescriber(),
		//        null);
		//}

		public static IdentityUser GetIdentityUser()
		{
			return new IdentityUser
			{
				Id = "123",
				UserName = "test@test.com",
				NormalizedUserName = "TEST@TEST.COM",
				PasswordHash = "test",
				Email = "test@test.com",
				NormalizedEmail = "TEST@TEST.COM",
				EmailConfirmed = true,
				AccessFailedCount = 0,
				ConcurrencyStamp = "",
				LockoutEnabled = false,
				PhoneNumber = "",
				PhoneNumberConfirmed = false,
				SecurityStamp = "",
				TwoFactorEnabled = false
			};
		}

		//public static UserModel GetSamplePerson()
		//{
		//    var person = new UserModel
		//    {
		//        Id = "Tim.Corey@corey.org",
		//        FirstName = "Tim",
		//        LastName = "Corey",
		//        EmailAddress = "Tim.Corey@corey.org"
		//    };

		//    return person;
		//}

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

		public static IList<IdentityRole> GetIdentityRoles()
		{
			var roles = new List<IdentityRole>
						{
								new IdentityRole{ Id = "1", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "y" },
								new IdentityRole{ Id = "2", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "y" },
								new IdentityRole{ Id = "3", Name = "Test", NormalizedName = "TEST", ConcurrencyStamp = "y" }
						};

			return roles;
		}

		//public static List<ApplicationUserModel> GetSampleApplicationUserModel()
		//{
		//    var outPut = new List<ApplicationUserModel>
		//    {
		//        new ApplicationUserModel
		//        { Id = "1", Email = "test@Test.com",
		//            Roles = new Dictionary<string, string>()
		//            {
		//                { "1", "Admin" },
		//                { "2", "User" }
		//            }
		//        },
		//        new ApplicationUserModel
		//        { Id = "2", Email = "test.two@Test.com",
		//            Roles = new Dictionary<string, string>()
		//            {
		//                { "1", "Admin" },
		//                { "2", "User" }
		//            }
		//        }
		//    };

		//    return outPut;
		//}

		public static IList<IdentityUser> GetSampleIdentityUsers()
		{
			var persons = new List<IdentityUser>
						{
								new IdentityUser
								{
										Id ="Tim.Corey@corey.org",
										UserName = "Tim.Corey@corey.org",
										Email = "Tim.Corey@corey.org",
										NormalizedUserName = "TIM.COREY@COREY.ORG",
										PasswordHash = "test",
										NormalizedEmail = "TIM.COREY@COREY.ORG",
										EmailConfirmed = true,
										AccessFailedCount = 0,
										ConcurrencyStamp = "",
										LockoutEnabled = false,
										PhoneNumber = "",
										PhoneNumberConfirmed = false,
										SecurityStamp = "",
										TwoFactorEnabled = false
								},
								new IdentityUser
								{
										Id ="Charity.Corey@corey.org",
										UserName = "Charity.Corey@corey.org",
										Email = "Charity.Corey@corey.org",
										NormalizedUserName = "CHARITY.COREY@COREY.ORG",
										PasswordHash = "test",
										NormalizedEmail = "CHARITY.COREY@COREY.ORG",
										EmailConfirmed = true,
										AccessFailedCount = 0,
										ConcurrencyStamp = "",
										LockoutEnabled = false,
										PhoneNumber = "",
										PhoneNumberConfirmed = false,
										SecurityStamp = "",
										TwoFactorEnabled = false
								},
								new IdentityUser
								{
										Id ="Jon.Corey@corey.org",
										UserName = "Jon.Corey@corey.org",
										Email = "Jon.Corey@corey.org",
										NormalizedUserName = "JON.COREY@COREY.ORG",
										PasswordHash = "test",
										NormalizedEmail = "JON.COREY@COREY.ORG",
										EmailConfirmed = true,
										AccessFailedCount = 0,
										ConcurrencyStamp = "",
										LockoutEnabled = false,
										PhoneNumber = "",
										PhoneNumberConfirmed = false,
										SecurityStamp = "",
										TwoFactorEnabled = false
								},
								new IdentityUser
								{
										Id ="Chris.Corey@corey.org",
										UserName = "Chris.Corey@corey.org",
										Email = "Chris.Corey@corey.org",
										NormalizedUserName = "CHRIS.COREY@COREY.ORG",
										PasswordHash = "test",
										NormalizedEmail = "CHRIS.COREY@COREY.ORG",
										EmailConfirmed = true,
										AccessFailedCount = 0,
										ConcurrencyStamp = "",
										LockoutEnabled = false,
										PhoneNumber = "",
										PhoneNumberConfirmed = false,
										SecurityStamp = "",
										TwoFactorEnabled = false
								}
						};

			return persons;
		}

		public static IList<IdentityUserRole<string>> GetSampleIdentityUserRoles()
		{
			var roles = new List<IdentityUserRole<string>>
						{
								new IdentityUserRole<string>{ UserId = "123", RoleId = "1" },
								new IdentityUserRole<string>{ UserId = "123", RoleId = "2" },
								new IdentityUserRole<string>{ UserId = "123", RoleId = "3" }
						};

			return roles;
		}

		public static void SetupUser(UserController sut, string userName)
		{
			var mockContext = new Mock<HttpContext>(MockBehavior.Loose);
			mockContext.SetupGet(hc => hc.User.Identity.Name).Returns(userName);
			mockContext.SetupGet(hc => hc.User.Identity.IsAuthenticated).Returns(true);
			sut.ControllerContext = new ControllerContext()
			{
				HttpContext = mockContext.Object
			};
		}
	}
}
