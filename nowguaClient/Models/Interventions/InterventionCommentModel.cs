using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Models.Interventions
{
    public class InterventionCommentModel
    {
		public string InterventionId { get; set; }
		public InterventionCommentUserModel User { get; set; }
		public string Message { get; set; }
		public long CreatedDate { get; set; }
	}

	/// <summary>
	/// Utilisateur qui a rédigé le commentaire
	/// </summary>
	public class InterventionCommentUserModel
	{
		public string UserId { get; set; }
		public string FullName { get; set; }

		public string CompanyId { get; set; }
	}
}
