using nowguaClient.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Services
{
    public interface IBaseService
    {

    }

    public class BaseService : IBaseService
    {
        internal ApiService _apiService { get; set; }
        internal SearchService _searchService { get; set; }

        internal string _baseRoot { get; set; }

        public BaseService(ApiService ApiService, SearchService SearchService, string BaseRoot)
        {
            this._apiService = ApiService;
            this._searchService = SearchService;
            this._baseRoot = BaseRoot;
        }
    }
}