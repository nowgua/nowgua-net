using nowguaClient.Models.ACLsModel;
using System.Collections.Generic;
using System.Linq;

namespace nowguaClient.Models.Users
{
    /// <summary>
    /// Utilisateur Nowgua
    /// </summary>
    public class UserModel 
    {
        /// <summary>
        /// Id 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nom complet (Prénonm + Nom)
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Indique si l'utilisateur est désactivé
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Prénom
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nom
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Nom API (si l'utilisateur est API)
        /// </summary>
        public string ApiUserName { get; set; }

        /// <summary>
        /// Email 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Téléphone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Société de l'utilisateur
        /// </summary>
        public UserCompanyModel Company { get; set; }

        /// <summary>
        /// Indique si il reçoit les rapports par mail
        /// </summary>
        public bool ReceiveReportMail { get; set; }
        
        /// <summary>
        /// Liste des rôles
        /// </summary>
        public List<LabelModel<string>> Roles { get; set; }

        /// <summary>
        /// Photo
        /// </summary>
        public string Pictures { get; set; }

        /// <summary>
        /// Indique si il s'agit d'un utilisateur API
        /// </summary>
        public bool ApiUser { get; set; }
    }
}