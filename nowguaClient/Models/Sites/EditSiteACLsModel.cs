using nowguaClient.Models.ACLsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Modèle de modification des informations de partage d'accès d'un site
    /// </summary>
    public class EditSiteACLsModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Sociétés ayant accès au site
        /// </summary>
        public List<EditACLModel> CompanyACLs { get; set; }

        /// <summary>
        /// Equipes ayant accès au site
        /// </summary>
        public List<EditACLModel> TeamACLs { get; set; }
    }
}
