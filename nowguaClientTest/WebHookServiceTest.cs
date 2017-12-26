using nowguaClient.Models;
using nowguaClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nowguaClientTest
{
    public class WebHookServiceTest : BaseTest
    {
        [Fact]
        public async void CRUDTest()
        {
            var webhookService = new WebHookService(ApiService, SearchService);
            var model = new CreateWebHookModel { Type = WebHookType.Site, URL = "https://api.monsite.com/key=d4s5qd4f8sf" };

            // Création
            string webhookId = await webhookService.Create(model);

            // Listing
            var WebHooks = await webhookService.List();
            var webhook = WebHooks.Find(w => w.Id == webhookId);
            Assert.NotNull(webhook);
            Assert.Equal(model.Type, webhook.Type);
            Assert.Equal(model.URL, webhook.URL);

            // Delete 
            await webhookService.Delete(webhookId);

            // Listing
            WebHooks = await webhookService.List();
            Assert.False(WebHooks.Exists(w => w.Id == webhookId));
        }
    }
}