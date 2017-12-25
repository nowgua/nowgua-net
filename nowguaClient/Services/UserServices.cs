using Nest;
using nowguaClient.Helpers;
using nowguaClient.Models.Interventions;
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
        Task<APIResponse<UserMeModel>> Get();
    }

    /// <summary>
    /// Gestion des utilisateurs
    /// </summary>
    public class UserService : BaseService, IUserService
    {
        public UserService(ApiService ApiService, SearchService SearchService) 
            : base(ApiService, SearchService, "api/1.0/users")
        {

        }

        /// <summary>
        /// Récupération des données de l'utilisateur en cours
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>UserMeModel</returns>
        public Task<APIResponse<UserMeModel>> Get()
        {
            return _apiService.Get<UserMeModel>("");
        }
    }
}