using Nest;
using nowguaClient.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using nowguaClient.Models.Users;

namespace nowguaClient.Helpers
{
    public interface ISearchService
    {
        List<TModel> Search<TModel>(Func<SearchDescriptor<TModel>, ISearchRequest> selector) where TModel : class;
        void Connect();
        string TypeName<TModel>() where TModel : class;
    }

    /// <summary>
    /// Moteur de recherche nowgua
    /// </summary>
    public class SearchService : ISearchService
    {
        private IApiService _apiService { get; }
        private ElasticClient _elasticClient;

        public bool Connected { get; set; }

        public SearchService(IApiService ApiService)
        {
            this._apiService = ApiService;
        }

        /// <summary>
        /// Recherche d'une entité nowgua (Intervention, Site etc...)
        /// </summary>
        /// <typeparam name="TModel">Type d'entité recherchée (Intervention, Site etc...)</typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public List<TModel> Search<TModel>(Func<SearchDescriptor<TModel>, ISearchRequest> selector) where TModel : class
        {
            Connect();
            var r  = _elasticClient.Search<TModel>(selector);

            return r.Hits.Select(item => item.Source).ToList();
        }

        /// <summary>
        /// Initialisation de la connection à ElasticSearch
        /// </summary>
        public void Connect()
        {
            if (!Connected)
            {
                var u = _apiService.Get<UserMeModel>("/api/1.0/users/me");
                u.Wait();

                _apiService.GlobalConfiguration.ElasticConnectionString = _apiService.GlobalConfiguration.ElasticConnectionString
                                                                    .Replace("https://", $"https://user_{u.Result.Id}:{u.Result.ELKPassword}@");

                var settings = new ConnectionSettings(new Uri(_apiService.GlobalConfiguration.ElasticConnectionString))
                                        .DefaultIndex(_apiService.GlobalConfiguration.ElasticIndex);

                _elasticClient = new ElasticClient(settings);

                Connected = true;
            }
        }

        public string TypeName<TModel>() where TModel : class
        {
            return typeof(TModel).Name.Replace("Model", "").ToLower() + "s";
        }
    }
}