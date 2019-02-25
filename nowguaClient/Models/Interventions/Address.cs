using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Models.Interventions
{
    public class Address
    {
        public string Text { get; set; }
		public string ExternalTextValue { get; set; }
		public double Latitude { get; set; }
        public double Longitude { get; set; }
		public AddressMode AddressMode { get; set; }
		public bool AddressType { get; set; }

        public List<string> Types { get; set; }
        public List<AddressEntityComponent> Components { get; set; }

        /// <summary>
        /// Adresse du site
        /// </summary>
        /// <param name="Text">Adresse au format texte</param>
        /// <param name="Latitude">Coordonnée de Latitude de l'adresse</param>
        /// <param name="Longitude">Coordonnée de Longitude de l'adresse</param>
        public Address(string Text, string ExternalTextValue, double Latitude, double Longitude)
        {
			this.ExternalTextValue = ExternalTextValue;
            this.Text = Text;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.AddressType = false;
            this.Types = new List<string>();
            this.Components = new List<AddressEntityComponent>();
        }

		public Address() { }
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

	public enum AddressMode
	{
		AutoCompletionMode = 0,
		ManualMode = 1,
		FreeMode = 2
	}
}
