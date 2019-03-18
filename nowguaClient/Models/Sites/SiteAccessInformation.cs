using nowguaClient.Models.ACLsModel;
using System.Collections.Generic;
using System.Linq;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Moyens d'accès
    /// </summary>
    public class SiteAccessInformation
    {
        /// <summary>
        /// Type de moyen d'accès
        /// </summary>
        public List<LabelModel<int>> Type { get; set; }

        /// <summary>
        /// Code d'accès
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Adresse de récupération des moyen d'accès
        /// </summary>
        public AddressModel Address { get; set; }

        /// <summary>
        /// Commentaire
        /// </summary>
        public string Commentaire { get; set; }

        /// <summary>
        /// Lieux des moyens récupération
        /// </summary>
        public LabelModel<int> LocationType { get; set; }

        /// <summary>
        /// Reference clé
        /// </summary>
        public string KeyRef { get; set; }

        public SiteAccessInformation(List<LabelModel<int>> Type,string Code, AddressModel Address, string Commentaire, LabelModel<int> LocationType, string KeyRef)
        {
            this.Type = Type;
            this.Code = Code;
            this.Address = Address;
            this.Commentaire = Commentaire;
            this.LocationType = LocationType;
			this.KeyRef = KeyRef;
        }

    }

}
