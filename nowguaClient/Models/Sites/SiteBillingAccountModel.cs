using nowguaClient.Models.Interventions;
using System;
using System.Collections.Generic;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Information de facturation du site
    /// </summary>
    public class SiteBillingAccountModel
    {
        /// <summary>
        /// Indique que l'adresse de facturation est différente de l'adresse du site
        /// </summary>
        public Boolean SiteBA { get; set; }

        /// <summary>
        /// Nom de l'adresse de facturation
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Adresse de facturation
        /// </summary>
        public AddressModel AddressBA { get; set; }
    }

    /// <summary>
    /// Adresse
    /// </summary>
    public class AddressModel
    {
        /// <summary>
        /// Adresse au format texte
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Latitude 
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// Coordonnées géographiques
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Meta données concernant l'adresse
        /// </summary>
        public List<string> Types { get; set; }

        /// <summary>
        /// Meta données concernant l'adresse
        /// </summary>
        public List<AddressEntityComponent> Components { get; set; }
    }

    /// <summary>
    /// Coordonnées géographiques
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Latitude 
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Lon { get; set; }
    }
}
