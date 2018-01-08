using nowguaClient.Helpers;
using nowguaClient.Models;
using nowguaClient.Models.Teams;
using nowguaClient.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace nowguaClientTest
{
    public class ApiServiceTest : BaseTest
    {
        [Fact]
        public async void GetTest()
        {
            var api = new ApiService(this.ConnectionSettings);
            var user = await api.Get<UserMeModel>("/api/1.0/users/me");

            Assert.NotNull(user);
            Assert.NotEmpty(user.FullName);
        }

        [Fact]
        public async void CRUDTest()
        {
            var api = new ApiService(this.ConnectionSettings);

            // Create
            var model = new CreateTeamModel { Name = "Test " + Rand(),  Description = "Description ..." };
            var createdTeam = await api.Post<CreateTeamModel, LabelIdModel<string>>("/api/1.0/teams", model);

            Assert.NotNull(createdTeam);
            Assert.NotEmpty(createdTeam.Id);

            // Read
            var team = await api.Get<TeamModel>($"/api/1.0/teams/{createdTeam.Id}");

            Assert.NotNull(team);
            Assert.NotEmpty(team.Name);
            Assert.Equal(model.Name, team.Name);
            Assert.Equal(model.Description, team.Description);

            // Edit
            var editModel = new EditTeamModel { Id = team.Id, Name = "Test 2 ", Description = "Description 2..." };
            await api.Put<EditTeamModel>("/api/1.0/teams", editModel);

            // Read
            team = await api.Get<TeamModel>($"/api/1.0/teams/{editModel.Id}");

            Assert.NotNull(team);
            Assert.NotEmpty(team.Name);
            Assert.Equal(editModel.Name, team.Name);
            Assert.Equal(editModel.Description, team.Description);

            // Delete 
            await api.Delete($"/api/1.0/teams/delete/{team.Id}");

            Thread.Sleep(2000);
			team = await api.Get<TeamModel>($"/api/1.0/teams/{editModel.Id}");
			Assert.NotNull(team);
		}

		[Fact]
        public async void DownloadTest()
        {
            var api = new ApiService(this.ConnectionSettings);
            var response = await api.Download("/api/1.0/files/5a412f990fcd2f0f2c973825");

            Assert.NotNull(response);

            File.WriteAllBytes("test.png", response);
        }

        [Fact]
        public void InitAuthProviderTest()
        {
            var api = new ApiService(this.ConnectionSettings);
            var auth = api.InitAuthProvider();

            Assert.NotNull(auth);
            Assert.NotNull(api.GlobalConfiguration);
            Assert.Equal("https://api.preprod.nowgua.com", auth.Audience);
            Assert.Equal("userdb-prod", auth.ClientConnexion);
        }

        [Fact]
        public void GenerateOrRefreshTokenTest()
        {
            var api = new ApiService(this.ConnectionSettings);

            // Génération du token
            string token = api.GenerateOrRefreshToken();
            Assert.NotEmpty(token);
            Assert.NotEmpty(api.Token);

            Thread.Sleep(2000);

            // Regénération du token (doit être identique)
            string token2 = api.GenerateOrRefreshToken();
            Assert.Equal(token, token2);
            Assert.Equal(token, api.Token);

            Thread.Sleep(2000);

            // Token expire dans 5 min, il doit être regénéré
            api.TokenExpiresDate = DateTime.Now.AddMinutes(5);
            string token3 = api.GenerateOrRefreshToken();
            Assert.NotEqual(token, token3);
            Assert.NotEqual(token, api.Token);
        }

        [Fact]
        public void GenerateJwtTokenTest()
        {
            var api = new ApiService(this.ConnectionSettings);
            api.InitAuthProvider();

            var token = api.GenerateJwtToken();
            Assert.NotEmpty(token.access_token);

            Thread.Sleep(2000);

            var token2 = api.GenerateJwtToken();
            Assert.NotEmpty(token2.access_token);
            Assert.NotEqual(token.access_token, token2.access_token);
        }

        [Fact]
        public void GetHttpClient()
        {
            var api = new ApiService(this.ConnectionSettings);
            var http = api.GetHttpClient();

            Assert.NotEmpty(api.Token);

            Assert.Equal("Bearer", http.DefaultRequestHeaders.Authorization.Scheme);
            Assert.Equal(api.Token, http.DefaultRequestHeaders.Authorization.Parameter);
        }
    }
}
