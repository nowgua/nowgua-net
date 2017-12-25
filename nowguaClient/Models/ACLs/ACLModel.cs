using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nowguaClient.Models.ACLsModel
{
    /// <summary>
    /// Modèle d'information de partage d'accès
    /// </summary>
    public class ACLModel
    {
        /// <summary>
        /// Identifiant du tenant
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nom du tenant
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id du rôle 
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Nom du rôle
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Partage hérité
        /// </summary>
        public bool Herited { get; set; }
    }

    public class CompanyACLs : List<ACLModel>
    {

    }

    public class TeamACLs : List<ACLModel>
    {

    }

    public class UserACLs : List<ACLModel>
    {

    }
}