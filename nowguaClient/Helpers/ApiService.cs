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
        Task<APIResponse<TResult>> Get<TResult>(string APIOperation);
        Task<APIResponse<TResult>> Post<TResult>(string APIOperation);
        Task<APIResponse<TResult>> Post<TModel, TResult>(string APIOperation, TModel Model);
        Task<APIResponse> Put(string APIOperation);
        Task<APIResponse> Put<TModel>(string APIOperation, TModel Model);
        Task<APIResponse> Delete(string APIOperation);
        Task<byte[]> Download(string APIOperation);
        void Connect();
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
        public NowguaConfiguration NowguaConfiguration { get; set; }

        private string Token { get; set; }

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
        public Task<APIResponse<TResult>> Get<TResult>(string APIOperation)
        {
            var httpClient = GetHttpClient();

            return httpClient.GetAsync(APIOperation)
                        .ContinueWith(r => new APIResponse<TResult>(r.Result));
        }

        /// <summary>
        /// Opération POST
        /// </summary>
        /// <typeparam name="TModel">Type de modèle envoyé</typeparam>
        /// <typeparam name="TResult">Type de résultat attendu</typeparam>
        /// <param name="APIOperation">URL de l'API</param>
        /// <param name="Model">Modèle à envoyer</param>
        /// <returns></returns>
        public Task<APIResponse<TResult>> Post<TModel, TResult>(string APIOperation, TModel Model)
        {
            var httpClient = GetHttpClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");

            return httpClient.PostAsync(APIOperation, httpContent)
                        .ContinueWith(r => new APIResponse<TResult>(r.Result));
        }

        /// <summary>
        /// Opération POST
        /// </summary>
        /// <typeparam name="TResult">Type de résultat attendu</typeparam>
        /// <param name="APIOperation">URL de l'API</param>
        /// <returns></returns>
        public Task<APIResponse<TResult>> Post<TResult>(string APIOperation)
        {
            var httpClient = GetHttpClient();
            var httpContent = new StringContent("", Encoding.UTF8, "application/json");

            return httpClient.PostAsync(APIOperation, httpContent)
                        .ContinueWith(r => new APIResponse<TResult>(r.Result));
        }

        /// <summary>
        /// Opération PUT
        /// </summary>
        /// <typeparam name="TModel">Type de modèle envoyé</typeparam>
        /// <param name="APIOperation">URL de l'API</param>
        /// <param name="Model">Modèle à envoyer</param>
        /// <returns></returns>
        public Task<APIResponse> Put<TModel>(string APIOperation, TModel Model)
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
        public Task<APIResponse> Put(string APIOperation)
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
        public Task<APIResponse> Delete(string APIOperation)
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
        /// Connexion à l'API
        /// </summary>
        public void Connect()
        {
            var r = this.Get<NowguaConfiguration>("api/1.0/appsettings/globalConfiguration");
            r.Wait();

            if (r.Result.Error != null)
                throw new Exception(r.Result.Error.Code + " " + r.Result.Error.Message);

            this.NowguaConfiguration = r.Result.Result;
        }

        /// <summary>
        /// Génération du Token de connexion
        /// </summary>
        /// <returns></returns>
        public string GenerateOrRefreshToken()
        {
            throw new NotImplementedException();
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
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Token);

            return httpClient;
        }
    }

    /// <summary>
    /// Response de l'API
    /// </summary>
    public class APIResponse
    {
        /// <summary>
        /// Détail de l'erreur 
        /// </summary>
        public APIResponseError Error { get; set; }

        /// <summary>
        /// Indique que la réponse est en erreur
        /// </summary>
        public bool OnError
        {
            get
            {
                return this.Error != null;
            }
        }

        public APIResponse(HttpResponseMessage ResponseMessage)
        {
            InitError(ResponseMessage);
        }

        internal void InitError(HttpResponseMessage ResponseMessage)
        {
            if (ResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                this.Error = new APIResponseError();
                this.Error.Code = (int)ResponseMessage.StatusCode;
                this.Error.Message = ResponseMessage.StatusCode.ToString();

                if (ResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var r = ResponseMessage.Content.ReadAsStringAsync();
                    r.Wait();

                    this.Error.Result = JsonConvert.DeserializeObject<APIBadRequestResult>(r.Result);
                }

                if (ResponseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var r = ResponseMessage.Content.ReadAsStringAsync();
                    r.Wait();

                    this.Error.Message = r.Result;
                }
            }
        }

        public APIResponse()
        {

        }
    }

    /// <summary>
    /// Response de l'API typé
    /// </summary>
    /// <typeparam name="TResult">Type de retour attendu</typeparam>
    public class APIResponse<TResult> : APIResponse
    {
        /// <summary>
        /// Résultat de l'API
        /// </summary>
        public TResult Result { get; set; }

        public APIResponse(HttpResponseMessage ResponseMessage)
        {
            this.InitError(ResponseMessage);

            if (ResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var r = ResponseMessage.Content.ReadAsStringAsync();
                r.Wait();

                this.Result = JsonConvert.DeserializeObject<TResult>(r.Result);
            }
        }

        public APIResponse()
        {

        }
    }

    /// <summary>
    /// Erreur de l'API
    /// </summary>
    public class APIResponseError
    {
        /// <summary>
        /// Code d'erreur HTTP
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Message de l'erreur
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Information sur l'erreur
        /// </summary>
        public object Result { get; set; }
    }

    public class APIBadRequestResult : Dictionary<string, List<string>>
    {

    }
}
