using nowguaClient;
using nowguaClient.Models.Interventions;
using nowguaClient.Models.Sites;
using System.Threading;
using Xunit;

namespace nowguaClientTest
{
    public class GroupSiteServiceTest : BaseTest
    {
        [Fact]
        public async void ScenarioTest()
        {
            var ng = new NowguaClient(ConnectionSettings);

			string groupName = "NowGua-test";
			string groupId = "5c2e04f1caaad304087ccaca";

			// Récupération des informations du groupe de site via le Nom
			var group = await ng.GroupsSites.GetByName(groupName);
            Assert.NotNull(group);
            Assert.Equal(groupName, group.Name);
            Assert.Equal(groupId, group.Id);

			// Récupération des informations du groupe de site via l'ID
			var group2 = await ng.GroupsSites.GetById(groupId);
			Assert.NotNull(group2);
			Assert.Equal(groupName, group2.Name);
			Assert.Equal(groupId, group2.Id);
		}
    }
}