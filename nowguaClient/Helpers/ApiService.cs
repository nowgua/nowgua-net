using Newtonsoft.Json;
using nowguaClient.Configurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace nowguaClient.Helpers
{
    public interface IApiService
    {
        NowguaConnectionSettings ConnectionSettings { get; set; }
        GlobalConfiguration GlobalConfiguration { get; set; }
        string Token { get; set; }
        DateTime TokenExpiresDate { get; set; }

        Task<TResult> Get<TResult>(string APIOperation);
        Task<TResult> Post<TModel, TResult>(string APIOperation, TModel Model);
        Task Put(string APIOperation);
        Task Put<TModel>(string APIOperation, TModel Model);
        Task Delete(string APIOperation);
        Task Delete<TModel>(string APIOperation, TModel Model);
        Task<byte[]> Download(string APIOperation);
		Task<byte[]> DownloadReport(string APIOperation);
	}

    /// <summary>
    /// Gestion des appels API
    /// </summary>
    public class ApiService : IApiService
    {
        /// <summary>
        /// <param name="ConnectionSettings">Information de connexion à l'API Nowgua</param>
        /// </summary>
        public NowguaConnectionSettings ConnectionSettings { get; set; }

        /// <summary>
        /// <param name="ConnectionSettings">Configuration de l'app nowgua</param>
        /// </summary>
        public GlobalConfiguration GlobalConfiguration { get; set; }

        /// <summary>
        /// Token de connexion
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Date d'expiration du token
        /// </summary>
        public DateTime TokenExpiresDate { get; set; }

        /// <summary>
        /// Connexion à l'API nowgua
        /// </summary>
        /// <param name="ConnectionSettings">Information de connexion à l'API Nowgua</param>
        public ApiService(NowguaConnectionSettings ConnectionSettings)
        {
            this.ConnectionSettings = ConnectionSettings;
        }

        /// <summary>
        /// Opération GET
        /// </summary>
        /// <typeparam name="TResult">Type de résultat attendu</typeparam>
        /// <param name="APIOperation">URL de l'API</param>
        /// <returns></returns>
        public Task<TResult> Get<TResult>(string APIOperation)
        {
            var httpClient = GetHttpClient();

            return httpClient.GetAsync(APIOperation)
                                .ContinueWith(r => APIResponse<TResult>.Parse(r.Result));
        }

        /// <summary>
        /// Opération POST
        /// </summary>
        /// <typeparam name="TModel">Type de modèle envoyé</typeparam>
        /// <typeparam name="TResult">Type de résultat attendu</typeparam>
        /// <param name="APIOperation">URL de l'API</param>
        /// <param name="Model">Modèle à envoyer</param>
        /// <returns></returns>
        public Task<TResult> Post<TModel, TResult>(string APIOperation, TModel Model)
        {
            var httpClient = GetHttpClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");

            return httpClient.PostAsync(APIOperation, httpContent)
                                .ContinueWith(r => APIResponse<TResult>.Parse(r.Result));
        }

        /// <summary>
        /// Opération PUT
        /// </summary>
        /// <typeparam name="TModel">Type de modèle envoyé</typeparam>
        /// <param name="APIOperation">URL de l'API</param>
        /// <param name="Model">Modèle à envoyer</param>
        /// <returns></returns>
        public Task Put<TModel>(string APIOperation, TModel Model)
        {
            var httpClient = GetHttpClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");

            return httpClient.PutAsync(APIOperation, httpContent)
                                .ContinueWith(r => new APIResponse(r.Result));
        }

        /// <summary>
        /// Opération PUT
        /// </summary>
        /// <param name="APIOperation">URL de l'API</param>
        /// <returns></returns>
        public Task Put(string APIOperation)
        {
            var httpClient = GetHttpClient();
            var httpContent = new StringContent("", Encoding.UTF8, "application/json");

            return httpClient.PutAsync(APIOperation, httpContent)
                                .ContinueWith(r => new APIResponse(r.Result));
        }

        /// <summary>
        /// Opération DELETE
        /// </summary>
        /// <param name="APIOperation">URL de l'API</param>
        /// <returns></returns>
        public Task Delete(string APIOperation)
        {
            var httpClient = GetHttpClient();

            return httpClient.DeleteAsync(APIOperation)
                                .ContinueWith(r => new APIResponse(r.Result));
        }

        /// <summary>
        /// Opération DELETE
        /// </summary>
        /// <typeparam name="TModel">Type de modèle envoyé</typeparam>
        /// <param name="APIOperation">URL de l'API</param>
        /// <param name="Model">Modèle à envoyer</param>
        /// <returns></returns>
        public Task Delete<TModel>(string APIOperation, TModel Model)
        {
            var httpClient = GetHttpClient();

            return httpClient.DeleteAsync(APIOperation)
                                .ContinueWith(r => new APIResponse(r.Result));
        }


        /// <summary>
        /// Opération Download
        /// </summary>
        /// <param name="APIOperation">URL de l'API</param>
        /// <returns></returns>
        public Task<byte[]> Download(string APIOperation)
        {
            var httpClient = GetHttpClient();

            return httpClient.GetAsync(APIOperation)
                        .ContinueWith(r => {
                            var content = r.Result.Content.ReadAsByteArrayAsync();
                            content.Wait();

                            return content.Result;
                        });
        }

		/// <summary>
		/// Opération Download
		/// </summary>
		/// <param name="APIOperation">URL de l'API</param>
		/// <returns></returns>
		public async Task<byte[]> DownloadReport(string APIOperation)
		{
			var httpClient = GetHttpClient();
			httpClient.Timeout = TimeSpan.FromMinutes(5);

			var PDFUrl = await httpClient.GetAsync(APIOperation)
						.ContinueWith(r =>
						{
							var content = r.Result.Content.ReadAsStringAsync();
							content.Wait();

							return content.Result;
						});


			Uri uri = new Uri(PDFUrl.Replace("\"",""));

			var httpClient2 = new HttpClient();

			byte[] pdfByte = await httpClient2.GetByteArrayAsync(uri);

			return pdfByte;
		}

		/// <summary>
		/// Connexion à l'API
		/// </summary>
		public GlobalConfiguration InitAuthProvider()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(this.ConnectionSettings.ApiBaseURL);

            var r = httpClient.GetAsync("/api/1.0/appsettings/globalConfiguration")
                        .ContinueWith(resp => new APIResponse<GlobalConfiguration>(resp.Result));

            r.Wait();

            if (r.Result.Error != null)
                throw new Exception(r.Result.Error.Code + " " + r.Result.Error.Message);


            this.GlobalConfiguration = r.Result.Result;
            return this.GlobalConfiguration;
        }

        /// <summary>
        /// Génération du Token de connexion
        /// </summary>
        /// <returns></returns>
        public string GenerateOrRefreshToken()
        {
            if (string.IsNullOrEmpty(this.Token))
            {
                this.InitAuthProvider();
                var token = GenerateJwtToken();
                this.Token = token.access_token;
                this.TokenExpiresDate = DateTime.Now.AddSeconds(token.expires_in);

                return this.Token;
            }

            if (DateTime.Compare(DateTime.Now.AddMinutes(15), this.TokenExpiresDate) > 0)
            {
                var token = GenerateJwtToken();
                this.Token = token.access_token;
                this.TokenExpiresDate = DateTime.Now.AddSeconds(token.expires_in);
            }  
            
            return this.Token;
        }

        /// <summary>
        /// Génération d'un Token
        /// </summary>
        /// <returns></returns>
        public AuthToken GenerateJwtToken()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(this.GlobalConfiguration.BaseUrl);

            var httpContent = new StringContent(JsonConvert.SerializeObject(
                                                    new AuthModel(this.ConnectionSettings.ClientId
                                                                    , this.ConnectionSettings.ClientSecret
                                                                    , this.GlobalConfiguration.Audience
                                                                 )
                                                )
                                                , Encoding.UTF8
                                                , "application/json"
                                            );

            var r = httpClient.PostAsync("", httpContent);
            r.Wait();

            var token = r.Result.Content.ReadAsStringAsync();
            token.Wait();

            return JsonConvert.DeserializeObject<AuthToken>(token.Result);
        }

        /// <summary>
        /// HttpClient 
        /// </summary>
        /// <returns></returns>
        public HttpClient GetHttpClient()
        {
            this.GenerateOrRefreshToken();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(ConnectionSettings.ApiBaseURL);
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

            return httpClient;
        }
    }
}