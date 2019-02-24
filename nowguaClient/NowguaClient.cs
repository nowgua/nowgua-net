using nowguaClient.Configurations;
using nowguaClient.Helpers;
using nowguaClient.Services;
using System;

namespace nowguaClient
{
    public interface INowguaClient
    {
        IInterventionService Interventions { get; }
        ISiteService Sites { get; }
        IWebHookService WebHooks { get; }
        IUserService Users { get; }
		IGroupSiteService GroupsSites { get; }
	}

    /// <summary>
    /// Client Nowgua 
    /// </summary>
    public class NowguaClient : INowguaClient
    {
        private IApiService _apiService { get; }

        private ISearchService _searchService { get; }

        /// <summary>
        /// Gestion des interventions
        /// </summary>
        public IInterventionService Interventions { get; internal set; }

        /// <summary>
        /// Gestion des sites
        /// </summary>
        public ISiteService Sites { get; internal set; }

        /// <summary>
        /// Gestion des webhooks
        /// </summary>
        public IWebHookService WebHooks { get; internal set; }

        /// <summary>
        /// Gestion des fichiers
        /// </summary>
        public IFileService Files { get; internal set; }

        /// <summary>
        /// Gestion des utilisateurs
        /// </summary>
        public IUserService Users { get; internal set; }

		/// <summary>
		/// Gestion des groupes de site
		/// </summary>
		public IGroupSiteService GroupsSites { get; internal set; }

		/// <summary>
		/// Gestion des groupes de site
		/// </summary>
		public ICompanyService Companies { get; internal set; }

		/// <summary>
		/// Connexion à nowgua
		/// </summary>
		/// <param name="ConnectionSettings">Information de connexion à l'API Nowgua</param>
		public NowguaClient(NowguaConnectionSettings ConnectionSettings)
        {
            this._apiService = new ApiService(ConnectionSettings);
            this._searchService = new SearchService(this._apiService);

            this.Interventions = new InterventionService(_apiService, _searchService);
            this.Sites = new SiteService(_apiService, _searchService);
            this.WebHooks = new WebHookService(_apiService, _searchService);
            this.Files = new FileService(_apiService, _searchService);
            this.Users = new UserService(_apiService, _searchService);
			this.GroupsSites = new GroupSiteService(_apiService, _searchService);
			this.Companies = new CompanyService(_apiService, _searchService);
		}
    }
}