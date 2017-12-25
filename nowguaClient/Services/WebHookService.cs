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
        Task<APIResponse<string>> Create(CreateWebHookModel createWebHookModel);
        Task<APIResponse> Edit(EditWebHookModel editWebHookModel);
        Task<APIResponse> Delete(string Id);
        APIResponse<List<WebHookModel>> List();
    }

    /// <summary>
    /// Gestion des webhooks
    /// </summary>
    public class WebHookService : BaseService, IWebHookService
    {
        public WebHookService(ApiService ApiService, SearchService SearchService)
            : base(ApiService, SearchService, "api/1.0/webhooks/")
        {

        }

        /// <summary>
        /// Création d'un webhook
        /// </summary>
        /// <param name="createWebHookModel">Modèle de création du webhook</param>
        /// <returns>Identifiant du webhook créé</returns>
        public Task<APIResponse<string>> Create(CreateWebHookModel createWebHookModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Suppression d'un webhook
        /// </summary>
        /// <param name="Id">Identifiant du webhook à supprimer</param>
        /// <returns></returns>
        public Task<APIResponse> Delete(string Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modification d'un webhook
        /// </summary>
        /// <param name="editWebHookModel">Modèle de modification du webhook</param>
        /// <returns></returns>
        public Task<APIResponse> Edit(EditWebHookModel editWebHookModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Listing de tous les webhooks
        /// </summary>
        /// <param name="selector"></param>
        /// <returns>Liste de webhooks</returns>
        public APIResponse<List<WebHookModel>> List()
        {
            throw new NotImplementedException();
        }
    }
}
