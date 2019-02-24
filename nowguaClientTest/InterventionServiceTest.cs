using nowguaClient;
using nowguaClient.Models.Interventions;
using System;
using System.Collections.Generic;
using System.IO;
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
            string TransmetterNumber = "myt3";
            var site = await ng.Sites.SearchTT(TransmetterNumber);

            // Création de l'intervention
            var interventionModel = new CreateInterventionModel(site[0].Id, 1, DateTime.Now, "Attention présence sur le site. Merci de contacter Mr Andre une fois arrivé sur place ...", "MemoCPGI");
            var interventionId = await ng.Interventions.Create(interventionModel);

			if (interventionModel.MemoCogi != "")
			{
				var AddMemoCogi = await ng.Interventions.AddMemoCogi(interventionId, new InterventionCommentCreateModel { Message = interventionModel.MemoCogi });
				Assert.True(AddMemoCogi.result);
			}

			Assert.NotEmpty(interventionId);

            // Récupération de toutes les informations d'une intervention
            var intervention = await ng.Interventions.Get(interventionId);
            Assert.NotNull(intervention);
            Assert.Equal(site[0].Id, intervention.Site.Id);
            Assert.Equal(interventionModel.Commentaire, intervention.Commentaire);
            Assert.Equal(interventionModel.AlarmType.Id, intervention.AlarmType.Id);
			Assert.Equal(intervention.Status.Id, (int)InterventionStatus.WaitingForSecurityAgent);


			// Recherche d'intervention
			var interventions = await ng.Interventions.Search(i => i.Type(ng.Interventions.SearchTypeName)
                                                                            .Query(q => q
                                                                                .Term(t => t.Site.TransmitterNumber, TransmetterNumber)
                                                                                && q.Term(t => t.AlarmType.Id, 1)
                                                                            ).Take(1000)
                                                                );
            Assert.NotEmpty(interventions);
            Assert.True(interventions.Exists(i => i.Id == interventionId));

			var cancel = await ng.Interventions.Cancel(interventionId, new CancelInterventionModel { CancellationReason = "testdepuis lib" });
			Assert.True(cancel.result);
		}

		[Fact]
		public async void DownloadTest()
		{
			var ng = new NowguaClient(ConnectionSettings);
			string InterventionId = "59fb3ea8176d501c949306a8";
			var intervention = await ng.Interventions.DownloadReport(InterventionId);

			Assert.NotNull(intervention);
			File.WriteAllBytes("test.pdf", intervention);
		}

		[Fact]
		public async void GetReportTest()
		{
			var ng = new NowguaClient(ConnectionSettings);
			string InterventionId = "5c474ddbaea3ff1728c0f0c5";
			var intervention = await ng.Interventions.Get(InterventionId);
			var interventionReport = await ng.Interventions.GetReport(InterventionId);

			Assert.NotNull(intervention);
			Assert.NotNull(interventionReport);
			//Assert.True(intervention.Report.Equals(interventionReport));
			Assert.Equal(intervention.Report.Pictures.Count, interventionReport.Pictures.Count);
			
			Assert.Equal(intervention.Report.Videos.Count, interventionReport.Videos.Count);
			Assert.Equal(intervention.Report.Instructions.Count, interventionReport.Instructions.Count);
		}
	}
}
