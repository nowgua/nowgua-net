using nowguaClient.Models.ACLsModel;
using nowguaClient.Models.Interventions;
using System.Collections.Generic;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Modèle de création d'un site
    /// </summary>
    public class GroupSiteModel
    {
		/// <summary>
		/// Id du groupe de site
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Nom du groupe de site
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Description du groupe de site
		/// </summary>
		public string Description { get; set; }
		
    }
}