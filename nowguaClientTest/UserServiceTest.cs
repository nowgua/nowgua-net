using nowguaClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nowguaClientTest
{
    public class UserServiceTest : BaseTest
    {
        [Fact]
        public async void GetCurrentTest()
        {
            var userService = new UserService(ApiService, SearchService);
            var currentUser = await userService.GetCurrentUser();

            Assert.NotNull(currentUser);
            Assert.NotEmpty(currentUser.Id);
        }

        [Fact]
        public async void GetTest()
        {
            var userService = new UserService(ApiService, SearchService);
            var user = await userService.Get("5c6bba950038a80a605433bb");

            Assert.NotNull(user);
            Assert.NotEmpty(user.Id);
        }
    }
}
