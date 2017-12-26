using nowguaClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nowguaClientTest
{
    public class SiteServiceTest : BaseTest
    {
        [Fact]
        public void CRUDTest()
        {
            var client = new NowguaClient(ConnectionSettings);



        }
    }
}
