using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nowguaClient.Models.ACLsModel
{
    /// <summary>
    /// Modèle de modification d'un accès 
    /// </summary>
    public class EditACLModel
    {
        /// <summary>
        /// Identifiant d'un tenant
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Id du role 
        /// </summary>
        public int RoleId { get; set; }
    }
}