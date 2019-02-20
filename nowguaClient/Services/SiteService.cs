using Nest;
using nowguaClient.Helpers;
using nowguaClient.Models;
using nowguaClient.Models.Sites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nowguaClient.Services
{
    public interface ISiteService : IBaseService
    {
        Task<string> Create(CreateSiteModel createSiteModel);
        Task<string> Edit(EditSiteModel editSiteModel);
        Task Share(EditSiteACLsModel editSiteACLsModel);
        Task Delete(string Id);
        Task<SiteModel> Get(string Id);
        Task<List<SiteLogModel>> GetLogs(string Id);
        Task<SiteModel> Search(string TransmitterNumber);
        Task<List<SiteModel>> Search(Func<SearchDescriptor<SiteModel>, ISearchRequest> selector);
    }

    /// <summary>
    /// Gestion des sites 
    /// </summary>
    public class SiteService : BaseService<SiteModel>, ISiteService
    {
        public SiteService(IApiService ApiService, ISearchService SearchService)
            : base(ApiService, SearchService, "/api/1.0/sites")
        {

        }

        /// <summary>
        /// Création d'un site 
        /// </summary>
        /// <param name="createSiteModel">Modèle de création du site</param>
        /// <returns>Identifiant du site créé</returns>
        public Task<string> Create(CreateSiteModel createSiteModel)
        {
            return _apiService.Post<CreateSiteModel, LabelIdModel<string>>($"{BaseRoot}", createSiteModel).ContinueWith(r => r.Result.Id);
        }

        /// <summary>
        /// Suppression d'un site
        /// </summary>
        /// <param name="Id">Identifiant du site à supprimer</param>
        /// <returns></returns>
        public Task Delete(string Id)
        {
            return _apiService.Delete($"{BaseRoot}/{Id}");
        }

        /// <summary>
        /// Modification des données d'un site
        /// </summary>
        /// <param name="editSiteModel">Modèle d'édition du site</param>
        /// <returns></returns>
        public Task<string> Edit(EditSiteModel editSiteModel)
        {
            return _apiService.Put<EditSiteModel, LabelIdModel<string>>($"{BaseRoot}", editSiteModel).ContinueWith(r => r.Result.Id);
        }

        /// <summary>
        /// Partage l'accès à un site 
        /// </summary>
        /// <param name="editSiteACLsModel">Modèle de modification des données de partage</param>
        /// <returns></returns>
        public Task Share(EditSiteACLsModel editSiteACLsModel)
        {
            return _apiService.Post<EditSiteACLsModel, LabelIdModel<string>>($"{BaseRoot}/acls", editSiteACLsModel);
        }

        /// <summary>
        /// Récupération de toutes les données d'un site
        /// </summary>
        /// <param name="Id">Identifiant du site</param>
        /// <returns>SiteModel</returns>
        public Task<SiteModel> Get(string Id)
        {
            return _apiService.Get<SiteModel>($"{BaseRoot}/{Id}");
        }

        /// <summary>
        /// Listing des logs d'un site
        /// </summary>
        /// <param name="Id">Identifiant du site</param>
        /// <returns>Liste de logs</returns>
        public Task<List<SiteLogModel>> GetLogs(string Id)
        {
            return _apiService.Get<List<SiteLogModel>>($"{BaseRoot}/{Id}/logs");
        }

        /// <summary>
        /// Recherche de site
        /// </summary>
        /// <param name="selector">Query ElasticSearch</param>
        /// <returns>Liste des sites correspondant à la recherche</returns>
        public Task<List<SiteModel>> Search(Func<SearchDescriptor<SiteModel>, ISearchRequest> selector)
        {
            List<SiteModel> sites = _searchService.Search<SiteModel>(selector);

            return Task.FromResult(sites);
        }

        public Task<SiteModel> Search(string TransmitterNumber)
        {
            List<SiteModel> sites = _searchService.Search<SiteModel>(u => u.Type(SearchTypeName)
                                                                        .Query(q => q.Term(new Field("transmitterNumber"), TransmitterNumber))
                                                                        .Size(10)
                                                                    );

            if (sites.Count == 0)
                return Task.FromResult<SiteModel>(null);

            return Task.FromResult(sites[0]);
        }
    }
}