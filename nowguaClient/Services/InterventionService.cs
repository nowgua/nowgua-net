using Nest;
using nowguaClient.Helpers;
using nowguaClient.Models;
using nowguaClient.Models.Interventions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nowguaClient.Services
{
    public interface IInterventionService : IBaseService
    {
        Task<string> Create(CreateInterventionModel createInterventionModel);
		Task<BooleanResult> AddMemoCogi(string Id, InterventionCommentCreateModel CreateMemoModel);
		Task<BooleanResult> Cancel(string Id, CancelInterventionModel cancelInterventionModel);
        Task<InterventionModel> Get(string Id);
		Task<List<InterventionCommentModel>> ListMemoCogi(string Id);
		Task<ReportModel> GetReport(string Id);
        Task<List<InterventionLogModel>> GetLogs(string Id);
        Task<List<InterventionModel>> Search(Func<SearchDescriptor<InterventionModel>, ISearchRequest> selector);
		Task<byte[]> DownloadReport(string Id);
    }

    /// <summary>
    /// Gestion des interventions
    /// </summary>
    public class InterventionService : BaseService<InterventionModel>, IInterventionService
    {
        public InterventionService(IApiService ApiService, ISearchService SearchService) 
            : base(ApiService, SearchService, "/api/1.0/interventions")
        {

        }

        /// <summary>
        /// Création d'une intervention
        /// </summary>
        /// <param name="createInterventionModel"></param>
        /// <returns>Identifiant de l'intervention créée</returns>
        public Task<string> Create(CreateInterventionModel createInterventionModel)
        {
            return _apiService.Post<CreateInterventionModel, LabelIdModel<string>>($"{BaseRoot}", createInterventionModel).ContinueWith(r => r.Result.Id);
        }

		/// <summary>
		/// Creation d'un memo COGI a la creation d'une intervention
		/// </summary>
		/// <param name="Id">Identifiant de l'intervention à récupérer</param>
		/// <param name="CreateMemoModel"></param>
		/// <returns>boolean</returns>
		public Task<BooleanResult> AddMemoCogi(string Id, InterventionCommentCreateModel CreateMemoModel)
		{
			return _apiService.Post<InterventionCommentCreateModel, BooleanResult>($"{BaseRoot}/{Id}/comments", CreateMemoModel);
		}

		/// <summary>
		/// Annulation de l'intervention
		/// </summary>
		/// <param name="Id">Identifiant de l'intervention à annuler</param>
		/// <param name="cancelInterventionModel">Modèle du cancel</param>
		/// <returns></returns>
		public Task<BooleanResult> Cancel(string Id, CancelInterventionModel cancelInterventionModel)
        {
            return _apiService.Put<CancelInterventionModel, BooleanResult>($"{BaseRoot}/{Id}/cancel", cancelInterventionModel);
        }

        /// <summary>
        /// Récupération de toutes les informations d'une interventio
        /// </summary>
        /// <param name="Id">Identifiant de l'intervention à récupérer</param>
        /// <returns>InterventionModel</returns>
        public Task<InterventionModel> Get(string Id)
        {
            return _apiService.Get<InterventionModel>($"{BaseRoot}/{Id}");
        }

		/// <summary>
		/// Récupération des MemosCogi d'une intervention
		/// </summary>
		/// <param name="Id">Identifiant de l'intervention à récupérer</param>
		/// <returns>List<InterventionCommentModel></returns>
		public Task<List<InterventionCommentModel>> ListMemoCogi(string Id)
		{
			return _apiService.Get<List<InterventionCommentModel>>($"{BaseRoot}/{Id}/comments");
		}

		/// <summary>
		/// Récupération des informations du rapport d'une intervention
		/// </summary>
		/// <param name="Id">Identifiant de l'intervention à récupérer</param>
		/// <returns>ReportModel</returns>
		public Task<ReportModel> GetReport(string Id)
        {
            return _apiService.Get<ReportModel>($"{BaseRoot}/{Id}/report");
        }

        /// <summary>
        /// Récupération des informations de traçabilité d'une intervention
        /// </summary>
        /// <param name="Id">Identifiant de l'intervention à récupérer</param>
        /// <returns>InterventionLogModel</returns>
        public Task<List<InterventionLogModel>> GetLogs(string Id)
        {
            return _apiService.Get<List<InterventionLogModel>>($"{BaseRoot}/{Id}/logs");
        }

        /// <summary>
        /// Recherche d'intervention
        /// </summary>
        /// <param name="selector">Query ElasticSearch</param>
        /// <returns>Liste des interventions correspondantes à la recherche</returns>
        public Task<List<InterventionModel>> Search(Func<SearchDescriptor<InterventionModel>, ISearchRequest> selector)
        {
            List<InterventionModel> interventions = _searchService.Search<InterventionModel>(selector);

            return Task.FromResult(interventions);
        }

        /// <summary>
        /// Téléchargement du rapport au format PDF
        /// </summary>
        /// <param name="Id">Identifiant de l'intervention</param>
        /// <returns></returns>
        public Task<byte[]> DownloadReport(string Id)
        {
            return _apiService.DownloadReport($"{BaseRoot}/export/pdf/{Id}");
        }
    }
}