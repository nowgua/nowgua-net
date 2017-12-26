using Nest;
using nowguaClient.Helpers;
using nowguaClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nowguaClient.Services
{
    public interface IWebHookService : IBaseService
    {
        Task<string> Create(CreateWebHookModel createWebHookModel);
        Task Delete(string Id);
        Task<List<WebHookModel>> List();
    }

    /// <summary>
    /// Gestion des webhooks
    /// </summary>
    public class WebHookService : BaseService<WebHookModel>, IWebHookService
    {
        public WebHookService(IApiService ApiService, ISearchService SearchService)
            : base(ApiService, SearchService, "/api/1.0/webhooks")
        {

        }

        /// <summary>
        /// Création d'un webhook
        /// </summary>
        /// <param name="createWebHookModel">Modèle de création du webhook</param>
        /// <returns>Identifiant du webhook créé</returns>
        public Task<string> Create(CreateWebHookModel createWebHookModel)
        {
            return _apiService.Post<CreateWebHookModel, LabelIdModel<string>>($"{BaseRoot}", createWebHookModel)
                        .ContinueWith(r => r.Result.Id);
        }

        /// <summary>
        /// Suppression d'un webhook
        /// </summary>
        /// <param name="Id">Identifiant du webhook à supprimer</param>
        /// <returns></returns>
        public Task Delete(string Id)
        {
            return _apiService.Delete($"{BaseRoot}/{Id}");
        }

        /// <summary>
        /// Listing de tous les webhooks
        /// </summary>
        /// <param name="selector"></param>
        /// <returns>Liste de webhooks</returns>
        public Task<List<WebHookModel>> List()
        {
            return _apiService.Get<List<WebHookModel>>($"{BaseRoot}");
        }
    }
}
