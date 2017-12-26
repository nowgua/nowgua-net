using nowguaClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nowguaClientTest
{
    public class NowguaClientTest : BaseTest
    {
        [Fact]
        public async void ConstructorTest()
        {
            var client = new NowguaClient(ConnectionSettings);

            Assert.NotNull(client.Users);
            Assert.NotNull(client.Files);
            Assert.NotNull(client.Interventions);
            Assert.NotNull(client.Sites);
            Assert.NotNull(client.WebHooks);
        }
    }
}
