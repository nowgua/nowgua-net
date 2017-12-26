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

            this.ConnectionSettings = new NowguaConnectionSettings("https://nowgua-preprod-api.azurewebsites.net"
                                                                    , "fsxCvlvhP2GkC82ihU3iJ0HljNpICAtn"
                                                                    , "w-eyX4Fn0FxObG4TXDRzq8P9UV9OeVGq02bgSvq7uOrLxVYwbKIfPXQPwaWSRktM"
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
