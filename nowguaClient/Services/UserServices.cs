using Nest;
using nowguaClient.Helpers;
using nowguaClient.Models.Interventions;
using nowguaClient.Models.Sites;
using nowguaClient.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace nowguaClient.Services
{
    public interface IUserService : IBaseService
    {
        Task<UserModel> Get(string Id);
		Task<UserMeModel> GetCurrentUser();
	}

    /// <summary>
    /// Gestion des utilisateurs
    /// </summary>
    public class UserService : BaseService<UserModel>, IUserService
    {
        public UserService(IApiService ApiService, ISearchService SearchService) 
            : base(ApiService, SearchService, "/api/1.0/users")
        {

        }

        /// <summary>
        /// Récupération d'un utilisateur
        /// </summary>
        /// <param name="Id">Identifiant de l'utilisateur</param>
        /// <returns></returns>
        public Task<UserModel> Get(string Id)
        {
            return _apiService.Get<UserModel>($"{BaseRoot}/{Id}");
        }

        /// <summary>
        /// Récupération de l'utilisateur connecté
        /// </summary>
        /// <returns>UserMeModel</returns>
        public Task<UserMeModel> GetCurrentUser()
        {
            return _apiService.Get<UserMeModel>($"{BaseRoot}/me");
        }

	}
}