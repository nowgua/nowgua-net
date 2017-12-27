using nowguaClient;
using nowguaClient.Models.Interventions;
using nowguaClient.Models.Sites;
using System.Threading;
using Xunit;

namespace nowguaClientTest
{
    public class SiteServiceTest : BaseTest
    {
        [Fact]
        public async void ScenarioTest()
        {
            var ng = new NowguaClient(ConnectionSettings);

            // Création d'un site
            var createModel = new CreateSiteModel("Site de Test", rd.Next(1000, 10000).ToString(), 2);

            // Adresse du site (obligatoire)
            createModel.Address = new Address("228 Boulevard Alsace-Lorraine, Rosny-sous-Bois, France", 48.882485, 2.494292);

            // Information de reconnaissance 
            createModel.Recognition.Access = "Moyen d'accès au site";
            createModel.Recognition.ExitInformations = "Information sur les issues du site";
            createModel.Notes = "Notes concernant le site";
            
            // Inscrutions d'intervention
            createModel.Instructions.Add(1, true); //L'agent doit t'il réaliser une ronde extérieure
            createModel.Instructions.Add(3, "123"); //Code secret pour s'assurer que c'est bien le client
            createModel.Instructions.Add(4, "963258"); //Code d'entrée sur le site
            // ...

            // Ajout de contact 
            createModel.Contacts.Add("Albert", "SMITH", "albert.smith@gmail.com", "+33600000000", true); // reception automatique des rapports d'intervention du site
            createModel.Contacts.Add("Henry", "KESTREL", "h.kestrel@outlook.com", "+33600000000", false);

            string siteId = await ng.Sites.Create(createModel);
            Assert.NotEmpty(siteId);

            // Récupération des informations du site 
            var site = await ng.Sites.Get(siteId);
            Assert.NotNull(site);
            Assert.Equal(createModel.Name, site.Name);
            Assert.Equal(createModel.TransmitterNumber, site.TransmitterNumber);
            Assert.Equal(createModel.Address.Text, site.Address.Text);

            // Recherche d'un site via numéro télétransmeteur
            var site2 = ng.Sites.Search(site.TransmitterNumber);
            Assert.NotNull(site);
            Assert.Equal(createModel.Name, site.Name);
            Assert.Equal(createModel.TransmitterNumber, site.TransmitterNumber);
            Assert.Equal(createModel.Address.Text, site.Address.Text);

            // Modification du site 
            EditSiteModel editSiteModel = await ng.Sites.Get(siteId);
            editSiteModel.Name = "Nouveau Nom";
            editSiteModel.TransmitterNumber = "T0123456789";
            editSiteModel.Address = new Address("229 Boulevard Alsace-Lorraine, Rosny-sous-Bois, France", 48.882486, 2.494292);

            await ng.Sites.Edit(editSiteModel);

            site = await ng.Sites.Get(siteId);
            Assert.NotNull(site);
            Assert.Equal(editSiteModel.Name, site.Name);
            Assert.Equal(editSiteModel.TransmitterNumber, site.TransmitterNumber);
            Assert.Equal(editSiteModel.Address.Text, site.Address.Text);

            // Get des logs
            var logs = await ng.Sites.GetLogs(siteId);
            Assert.NotNull(logs);
            Assert.NotEmpty(logs);

            // Suppression du site 
            await ng.Sites.Delete(siteId);

            Thread.Sleep(3000);
            var sites = await ng.Sites.Search(s => s.Type(ng.Sites.SearchTypeName).Query(q => q.MatchAll()).Take(1000));
            Assert.NotNull(sites);
            Assert.NotEmpty(sites);
            Assert.False(sites.Exists(s => s.Id == siteId));
        }
    }
}