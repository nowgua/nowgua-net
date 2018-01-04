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

			string groupName = "NowGua-Group-test1";
			string groupId = "5a4b435c20c6c622587e2ca6";

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