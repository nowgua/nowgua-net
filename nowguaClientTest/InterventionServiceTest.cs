using nowguaClient;
using nowguaClient.Models.Interventions;
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
        public async void ScenarioTest()
        {
            var ng = new NowguaClient(ConnectionSettings);

            // Récupération du site
            string TransmetterNumber = "3241";
            var site = await ng.Sites.Search(TransmetterNumber);

            // Création de l'intervention
            var interventionModel = new CreateInterventionModel(site.Id, 1, DateTime.Now, "Attention présence sur le site. Merci de contacter Mr Andre une fois arrivé sur place ...");
            var interventionId = await ng.Interventions.Create(interventionModel);

            Assert.NotEmpty(interventionId);

            // Récupération de toutes les informations d'une intervention
            var intervention = await ng.Interventions.Get(interventionId);
            Assert.NotNull(intervention);
            Assert.Equal(site.Id, intervention.Site.Id);
            Assert.Equal(interventionModel.Commentaire, intervention.Commentaire);
            Assert.Equal(interventionModel.AlarmType.Id, intervention.AlarmType.Id);

            // Recherche d'intervention

            var interventions = await ng.Interventions.Search(i => i.Type(ng.Interventions.SearchTypeName)
                                                                            .Query(q => q
                                                                                .Term(t => t.Site.TransmitterNumber, TransmetterNumber)
                                                                                && q.Term(t => t.AlarmType.Id, 1)
                                                                            ).Take(1000)
                                                                );
            Assert.NotEmpty(interventions);
            Assert.True(interventions.Exists(i => i.Id == interventionId));


        }
    }
}
