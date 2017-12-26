using nowguaClient.Helpers;
using nowguaClient.Models.Interventions;
using nowguaClient.Models.Sites;
using nowguaClient.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nowguaClientTest
{
    public class SearchServiceTest : BaseTest
    {
        [Fact]
        public void SearchTest()
        {
            var search = new SearchService(ApiService);
            var sites = search.Search<SiteModel>(u => u.Type(search.TypeName<SiteModel>())
                                                        .Query(q => q.MatchAll())
                                                        .Size(1000)
                                                );

            Assert.NotEqual(0, sites.Count);
        }

        [Fact]
        public async void ConnectTest()
        {
            var search = new SearchService(ApiService);

            Assert.False(search.Connected);
            search.Connect();
            Assert.True(search.Connected);
            Assert.Contains("@", ApiService.GlobalConfiguration.ElasticConnectionString);
        }
    }
}
