using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Models.Interventions
{
    public class Address
    {
        public string Text { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public List<string> Types { get; set; }
        public List<AddressEntityComponent> Components { get; set; }

        public Address()
        {
            this.Types = new List<string>();
            this.Components = new List<AddressEntityComponent>();
        }
    }

    public class AddressEntityComponent
    {
        public string Long_Name { get; set; }
        public string Short_Name { get; set; }
        public List<string> Types { get; set; }

        public AddressEntityComponent()
        {
            this.Types = new List<string>();
        }
    }
}
