using Xunit;
using nowguaClient.Helpers;
using System.Net.Http;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace nowguaClientTest
{
    public class APIResponseTest
    {
        [Fact]
        public void APIResponseNoTypeTest()
        {
            APIResponse response = new APIResponse();
            Assert.Null(response.Error);
            Assert.False(response.OnError);
        }

        [Fact]
        public void APIResponseNoTypeOKStatusTest()
        {
            HttpResponseMessage m = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            m.Content = new StringContent("no content");

            APIResponse response = new APIResponse(m);
            Assert.Null(response.Error);
            Assert.False(response.OnError);
        }

        [Fact]
        public void APIResponseTypeOKStatusTest()
        {
            TestModel TestModel = new TestModel { Id = "Identifiant", Name = "Nom" };
            HttpResponseMessage m = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            m.Content = new StringContent(JsonConvert.SerializeObject(TestModel));

            APIResponse<TestModel> response = new APIResponse<TestModel>(m);
            Assert.Null(response.Error);
            Assert.False(response.OnError);
            Assert.NotNull(response.Result);
            Assert.Equal(TestModel.Id, response.Result.Id);
            Assert.Equal(TestModel.Name, response.Result.Name);
        }

        [Fact]
        public void APIResponseNoTypeBadRequestStatusTest()
        {
            APIBadRequestResult BadRequestResult = new APIBadRequestResult();
            BadRequestResult.Add("Name", new List<string> { "The Name field is required.", "The Name ..." });

            HttpResponseMessage m = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            m.Content = new StringContent(JsonConvert.SerializeObject(BadRequestResult));

            APIResponse response = new APIResponse(m);
            Assert.NotNull(response.Error);
            Assert.True(response.OnError);
            Assert.Equal(400, response.Error.Code);
            Assert.Equal("BadRequest", response.Error.Message);
            Assert.Equal(BadRequestResult, response.Error.Result);
        }

        [Fact]
        public void APIResponseNoTypeForbiddenStatusTest()
        {
            HttpResponseMessage m = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);

            APIResponse response = new APIResponse(m);
            Assert.NotNull(response.Error);
            Assert.True(response.OnError);
            Assert.Equal(403, response.Error.Code);
            Assert.Equal("Forbidden", response.Error.Message);
        }

        [Fact]
        public void APIResponseNoTypeUnauthorizedStatusTest()
        {
            HttpResponseMessage m = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

            APIResponse response = new APIResponse(m);
            Assert.NotNull(response.Error);
            Assert.True(response.OnError);
            Assert.Equal(401, response.Error.Code);
            Assert.Equal("Unauthorized", response.Error.Message);
        }

        [Fact]
        public void APIResponseNoTypeNotFoundStatusTest()
        {
            HttpResponseMessage m = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);

            APIResponse response = new APIResponse(m);
            Assert.NotNull(response.Error);
            Assert.True(response.OnError);
            Assert.Equal(404, response.Error.Code);
            Assert.Equal("NotFound", response.Error.Message);
        }

        [Fact]
        public void APIResponseNoTypeInternalServerErrorStatusTest()
        {
            HttpResponseMessage m = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            m.Content = new StringContent("Message d'erreur");

            APIResponse response = new APIResponse(m);
            Assert.NotNull(response.Error);
            Assert.True(response.OnError);
            Assert.Equal(500, response.Error.Code);
            Assert.Equal("Message d'erreur", response.Error.Message);
        }
    }

    public class TestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}