using Autofac.Extras.Moq;
using IRCERDataManager.Library.DataAccess;
using IRCERDataManager.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IRCERApi.Controllers.UnitTests
{
    public class UserControllerUnitTests
    {
        [Theory]
        [InlineData("Tim.Corey@corey.org")]
        [InlineData("Charity.Corey@corey.org")]
        [InlineData("Jon.Corey@corey.org")]
        [InlineData("Chris.Corey@corey.org")]
        public void GetById_ShouldReturnTheLoggedOnUser_Test(string userName)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userData = GetSamplePeople().Where(a => a.Id == userName).ToList();

                mock.Mock<IUserData>()
                    .Setup(x => x.GetUserById(userName))
                    .Returns(userData);

                var sut = mock.Create<UserController>();

                SetupUser(sut, userName);

                //Act

                var result = sut.GetById();

                //Assert

                Assert.True(result != null);

                Assert.Equal(userName, sut.User.Identity.Name);

                Assert.Equal(userName, result.Id);
            }
        }

        [Fact()]
        public void GetAllUsers_Test()
        {
            //Arrange

            //Act

            //Assert

            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetAllRoles_Test()
        {
            //Arrange

            //Act

            //Assert

            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void AddARole_Test()
        {
            //Arrange

            //Act

            //Assert

            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void RemoveARole_Test()
        {
            //Arrange

            //Act

            //Assert

            Assert.True(false, "This test needs an implementation");
        }

        private void SetupUser(UserController sut, string userName)
        {
            var mockContext = new Mock<HttpContext>(MockBehavior.Loose);
            mockContext.SetupGet(hc => hc.User.Identity.Name).Returns(userName);
            mockContext.SetupGet(hc => hc.User.Identity.IsAuthenticated).Returns(true);
            sut.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
        }

        private List<UserModel> GetSamplePeople()
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
    }
}