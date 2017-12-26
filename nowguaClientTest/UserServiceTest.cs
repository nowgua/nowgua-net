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
            var currentUser = await userService.Get();

            Assert.NotNull(currentUser);
            Assert.NotEmpty(currentUser.Id);
        }

        [Fact]
        public async void GetTest()
        {
            var userService = new UserService(ApiService, SearchService);
            var currentUser = await userService.Get();
            var user = await userService.Get(currentUser.Id);

            Assert.NotNull(user);
            Assert.NotEmpty(user.Id);
        }
    }
}
