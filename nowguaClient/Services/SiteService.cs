using Nest;
using nowguaClient.Helpers;
using nowguaClient.Models.Sites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nowguaClient.Services
{
    public interface ISiteService : IBaseService
    {
        Task<APIResponse<string>> Create(CreateSiteModel createSiteModel);
        Task<APIResponse> Edit(EditSiteModel editSiteModel);
        Task<APIResponse> Share(EditSiteACLsModel editSiteACLsModel);
        Task<APIResponse> Delete(string Id);
        Task<APIResponse<SiteModel>> Get(string Id);
        Task<APIResponse<List<SiteLogModel>>> GetLogs(string Id);
        Task<APIResponse<List<SiteModel>>> Search(Func<SearchDescriptor<SiteModel>, ISearchRequest> selector);
    }

    /// <summary>
    /// Gestion des sites 
    /// </summary>
    public class SiteService : BaseService, ISiteService
    {
        public SiteService(ApiService ApiService, SearchService SearchService)
            : base(ApiService, SearchService, "api/1.0/sites/")
        {

        }

        /// <summary>
        /// Création d'un site 
        /// </summary>
        /// <param name="createSiteModel">Modèle de création du site</param>
        /// <returns>Identifiant du site créé</returns>
        public Task<APIResponse<string>> Create(CreateSiteModel createSiteModel)
        {
            return _apiService.Post<CreateSiteModel, string>("", createSiteModel);
        }

        /// <summary>
        /// Suppression d'un site
        /// </summary>
        /// <param name="Id">Identifiant du site à supprimer</param>
        /// <returns></returns>
        public Task<APIResponse> Delete(string Id)
        {
            return _apiService.Delete($"{Id}");
        }

        /// <summary>
        /// Modification des données d'un site
        /// </summary>
        /// <param name="editSiteModel">Modèle d'édition du site</param>
        /// <returns></returns>
        public Task<APIResponse> Edit(EditSiteModel editSiteModel)
        {
            return _apiService.Put<EditSiteModel>("", editSiteModel);
        }

        /// <summary>
        /// Partage l'accès à un site 
        /// </summary>
        /// <param name="editSiteACLsModel">Modèle de modification des données de partage</param>
        /// <returns></returns>
        public Task<APIResponse> Share(EditSiteACLsModel editSiteACLsModel)
        {
            return _apiService.Put<EditSiteACLsModel>("acls", editSiteACLsModel);
        }

        /// <summary>
        /// Récupération de toutes les données d'un site
        /// </summary>
        /// <param name="Id">Identifiant du site</param>
        /// <returns>SiteModel</returns>
        public Task<APIResponse<SiteModel>> Get(string Id)
        {
            return _apiService.Get<SiteModel>($"{Id}");
        }

        /// <summary>
        /// Listing des logs d'un site
        /// </summary>
        /// <param name="Id">Identifiant du site</param>
        /// <returns>Liste de logs</returns>
        public Task<APIResponse<List<SiteLogModel>>> GetLogs(string Id)
        {
            return _apiService.Get<List<SiteLogModel>>($"{Id}/logs");
        }

        /// <summary>
        /// Recherche de site
        /// </summary>
        /// <param name="selector">Query ElasticSearch</param>
        /// <returns>Liste des sites correspondant à la recherche</returns>
        public Task<APIResponse<List<SiteModel>>> Search(Func<SearchDescriptor<SiteModel>, ISearchRequest> selector)
        {
            APIResponse<List<SiteModel>> r = new APIResponse<List<SiteModel>>();
            r.Result = _searchService.Search<SiteModel>(selector);

            return Task.FromResult(r);
        }
    }
}