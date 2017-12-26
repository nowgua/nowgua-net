using nowguaClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nowguaClientTest
{
    public class InterventionServiceTest : BaseTest
    {
        [Fact]
        public void ScenarioTest()
        {
            var client = new NowguaClient(ConnectionSettings);



        }
    }
}
