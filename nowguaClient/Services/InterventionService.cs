using Nest;
using nowguaClient.Helpers;
using nowguaClient.Models.Interventions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nowguaClient.Services
{
    public interface IInterventionService : IBaseService
    {
        Task<APIResponse<string>> Create(CreateInterventionModel createInterventionModel);
        Task<APIResponse> Cancel(string Id, CancelInterventionModel cancelInterventionModel);
        Task<APIResponse<InterventionModel>> Get(string Id);
        Task<APIResponse<ReportModel>> GetReport(string Id);
        Task<APIResponse<List<InterventionLogModel>>> GetLogs(string Id);
        Task<APIResponse<List<InterventionModel>>> Search(Func<SearchDescriptor<InterventionModel>, ISearchRequest> selector);
    }

    /// <summary>
    /// Gestion des interventions
    /// </summary>
    public class InterventionService : BaseService, IInterventionService
    {
        public InterventionService(ApiService ApiService, SearchService SearchService) 
            : base(ApiService, SearchService, "api/1.0/interventions")
        {

        }

        /// <summary>
        /// Création d'une intervention
        /// </summary>
        /// <param name="createInterventionModel"></param>
        /// <returns>Identifiant de l'intervention créée</returns>
        public Task<APIResponse<string>> Create(CreateInterventionModel createInterventionModel)
        {
            return _apiService.Post<CreateInterventionModel, string>("", createInterventionModel);
        }

        /// <summary>
        /// Annulation de l'intervention
        /// </summary>
        /// <param name="Id">Identifiant de l'intervention à annuler</param>
        /// <param name="cancelInterventionModel">Modèle du cancel</param>
        /// <returns></returns>
        public Task<APIResponse> Cancel(string Id, CancelInterventionModel cancelInterventionModel)
        {
            return _apiService.Put<CancelInterventionModel>($"{_baseRoot}/{Id}/cancel", cancelInterventionModel);
        }

        /// <summary>
        /// Récupération de toutes les informations d'une interventio
        /// </summary>
        /// <param name="Id">Identifiant de l'intervention à récupérer</param>
        /// <returns>InterventionModel</returns>
        public Task<APIResponse<InterventionModel>> Get(string Id)
        {
            return _apiService.Get<InterventionModel>(Id);
        }

        /// <summary>
        /// Récupération des informations du rapport d'une intervention
        /// </summary>
        /// <param name="Id">Identifiant de l'intervention à récupérer</param>
        /// <returns>ReportModel</returns>
        public Task<APIResponse<ReportModel>> GetReport(string Id)
        {
            return _apiService.Get<ReportModel>($"{_baseRoot}/{Id}/report");
        }

        /// <summary>
        /// Récupération des informations de traçabilité d'une intervention
        /// </summary>
        /// <param name="Id">Identifiant de l'intervention à récupérer</param>
        /// <returns>InterventionLogModel</returns>
        public Task<APIResponse<List<InterventionLogModel>>> GetLogs(string Id)
        {
            return _apiService.Get<List<InterventionLogModel>>($"{_baseRoot}/{Id}/logs");
        }

        /// <summary>
        /// Recherche d'intervention
        /// </summary>
        /// <param name="selector">Query ElasticSearch</param>
        /// <returns>Liste des interventions correspondantes à la recherche</returns>
        public Task<APIResponse<List<InterventionModel>>> Search(Func<SearchDescriptor<InterventionModel>, ISearchRequest> selector)
        {
            APIResponse<List<InterventionModel>> r = new APIResponse<List<InterventionModel>>();
            r.Result = _searchService.Search<InterventionModel>(selector);

            return Task.FromResult(r);
        }
    }
}