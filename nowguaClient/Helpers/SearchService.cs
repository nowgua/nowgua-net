using Nest;
using nowguaClient.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace nowguaClient.Helpers
{
    public interface ISearchService
    {
        List<TModel> Search<TModel>(Func<SearchDescriptor<TModel>, ISearchRequest> selector) where TModel : class;
    }

    /// <summary>
    /// Moteur de recherche nowgua
    /// </summary>
    public class SearchService : ISearchService
    {
        private ElasticSearchConfiguration _elasticSearchConfiguration;
        private ElasticClient _elasticClient;

        public SearchService(ElasticSearchConfiguration ElasticSearchConfiguration)
        {
            this._elasticSearchConfiguration = ElasticSearchConfiguration;
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
            return _elasticClient.Search<TModel>(selector).Hits.Select(item => item.Source).ToList();
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }
    }
}