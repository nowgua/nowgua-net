using Nest;
using nowguaClient.Helpers;
using nowguaClient.Models;
using nowguaClient.Models.Sites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nowguaClient.Services
{
    public interface IGroupSiteService : IBaseService
    {
        Task<GroupSiteModel> GetByName(string Name);

		Task<GroupSiteModel> GetById(string Id);
	}

    /// <summary>
    /// Gestion des sites 
    /// </summary>
    public class GroupSiteService : BaseService<GroupSiteModel>, IGroupSiteService
	{
        public GroupSiteService(IApiService ApiService, ISearchService SearchService)
            : base(ApiService, SearchService, "/api/1.0/sites/groups")
        {

        }

		/// <summary>
		/// Récupération d'un groupe de site via le nom
		/// </summary>
		/// <param name="Name">nom du groupe de site</param>
		/// <returns>GroupSiteModel</returns>
		public Task<GroupSiteModel> GetByName(string Name)
        {
            return _apiService.Get<GroupSiteModel>($"{BaseRoot}/search/{Name}");
        }

		/// <summary>
		/// Récupération d'un groupe de site via l'id
		/// </summary>
		/// <param name="Id">nom du groupe de site</param>
		/// <returns>GroupSiteModel</returns>
		public Task<GroupSiteModel> GetById(string Id)
		{
			return _apiService.Get<GroupSiteModel>($"{BaseRoot}/{Id}");
		}
    }
}