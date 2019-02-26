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

		public static implicit operator EditACLModel(ACLModel Model)
		{
			EditACLModel editAclsModel = new EditACLModel();
			editAclsModel.Id = Model.Id;
			editAclsModel.RoleId = Model.RoleId;

			return editAclsModel;
		}
	}
}