using nowguaClient.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Services
{
    public interface IBaseService
    {

    }

    public class BaseService<TModel> : IBaseService where TModel : class
    {
        internal IApiService _apiService { get; set; }
        internal ISearchService _searchService { get; set; }

        public string BaseRoot { get; internal set; }

        /// <summary>
        /// Nom du type pour la recherche ElasticSearch
        /// </summary>
        public string SearchTypeName
        {
            get
            {
                return _searchService.TypeName<TModel>();
            }
        }

        public BaseService(IApiService ApiService, ISearchService SearchService, string BaseRoot)
        {
            this._apiService = ApiService;
            this._searchService = SearchService;
            this.BaseRoot = BaseRoot;
        }
    }
}