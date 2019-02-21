using nowguaClient.Configurations;
using nowguaClient.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nowguaClientTest
{
    public class BaseTest
    {
        public ApiService ApiService { get; set; }
        public SearchService SearchService { get; set; }
        public NowguaConnectionSettings ConnectionSettings { get; set; }
        public Random rd { get; set; }

        public BaseTest()
        {
            this.rd = new Random();

            this.ConnectionSettings = new NowguaConnectionSettings("https://nowgua-preprod-api-staging.azurewebsites.net"
                                                                    , "n9INOzup9V2Dz6NFGdrqv7wICJ7qBFlr"
																	, "NeD2D8hDpgCcd74chwVTeVP7w29wVtONcoCBy_a8dckkQATN2RH8q8QoVCpPtN0T"
																	);

            this.ApiService = new ApiService(this.ConnectionSettings);
            this.SearchService = new SearchService(this.ApiService);
        }

        public int Rand()
        {
            return this.rd.Next(1, 1000000);
        }
    }
}
