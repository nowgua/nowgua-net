using nowguaClient.Models.Sites;
using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Models.Compagnies
{
    public class CompanyModel
    {
		public string Id { get; set; }
		public string Name { get; set; }
		public string Siren { get; set; }
		public string Siret { get; set; }
		public string Phone1 { get; set; }
		public string Phone2 { get; set; }
		public string Email { get; set; }
		public string FileLogoCompany { get; set; }
		public string Commentaire { get; set; }
		public string CardId { get; set; }
		public bool AgentStatusAvailabilityControl { get; set; }
		public string CalendarId { get; set; }

		public AddressModel Address { get; set; }

		public bool HideContactSite { get; set; }

		public bool Disabled { get; set; }

		public bool Deleted { get; set; }

		public long DeletedDate { get; set; }
	}
}
