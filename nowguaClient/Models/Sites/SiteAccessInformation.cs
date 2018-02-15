using System.Collections.Generic;
using System.Linq;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Instruction
    /// </summary>
    public class SiteAccessInformation 
    {
        public List<LabelModel<int>> Type { get; set; }
        public string Code { get; set; }

        public AddressModel Address { get; set; }
        public string Commentaire { get; set; }
        public LabelModel<int> LocationType { get; set; }
        public string KeyRef { get; set; }

        public SiteAccessInformation(List<LabelModel<int>> Type,string Code, AddressModel Address, string Commentaire,LabelModel<int> LocationType,string KeyRef )
        {
            this.Type = Type;
            this.Code = Code;
            this.Address = Address;
            this.Commentaire = Commentaire;
            this.LocationType = LocationType;
            this.KeyRef = KeyRef;
        }

        public SiteAccessInformation()
        {

        }
    }


}
