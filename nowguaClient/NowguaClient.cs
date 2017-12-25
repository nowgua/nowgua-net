using nowguaClient.Configurations;
using nowguaClient.Helpers;
using nowguaClient.Services;
using System;

namespace nowguaClient
{
    public interface INowguaClient
    {
        InterventionService Interventions { get; }
        SiteService Sites { get; }
        WebHookService WebHooks { get; }
    }

    /// <summary>
    /// Client Nowgua 
    /// </summary>
    public class NowguaClient : INowguaClient
    {
        private ApiService _apiService { get; }
        private SearchService _searchService { get; }

        /// <summary>
        /// Gestion des interventions
        /// </summary>
        public InterventionService Interventions { get; internal set; }

        /// <summary>
        /// Gestion des sites
        /// </summary>
        public SiteService Sites { get; internal set; }

        /// <summary>
        /// Gestion des webhooks
        /// </summary>
        public WebHookService WebHooks { get; internal set; }

        /// <summary>
        /// Gestion des fichiers
        /// </summary>
        public FileService Files { get; internal set; }

        /// <summary>
        /// Connexion à nowgua
        /// </summary>
        /// <param name="ConnectionSettings">Information de connexion à l'API Nowgua</param>
        public NowguaClient(NowguaConnectionSettings ConnectionSettings)
        {
            this._apiService = new ApiService(ConnectionSettings);
            this._apiService.Connect();
            this._searchService = new SearchService(this._apiService.NowguaConfiguration.ElasticSearch);

            this.Interventions = new InterventionService(_apiService, _searchService);
            this.Sites = new SiteService(_apiService, _searchService);
            this.WebHooks = new WebHookService(_apiService, _searchService);
            this.Files = new FileService(_apiService, _searchService);
        }
    }
}