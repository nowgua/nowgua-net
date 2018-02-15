using System.Collections.Generic;
using System.Linq;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Instruction
    /// </summary>
    public class SiteAccessInformation 
    {
        public List<BaseEntityLabel<int>> Type { get; set; }
        public string Code { get; set; }

        public Address Address { get; set; }
        public string Commentaire { get; set; }
        public BaseEntityLabel<int> LocationType { get; set; }
        public string KeyRef { get; set; }

        public SiteAccessInformation(List<BaseEntityLabel<int>> Type,string Code, Address Address, string Commentaire,BaseEntityLabel<int> LocationType,string KeyRef )
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
