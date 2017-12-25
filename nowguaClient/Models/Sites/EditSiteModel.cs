using nowguaClient.Models;
using nowguaClient.Models.Interventions;
using System.Collections.Generic;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Modèle de modification d'un site
    /// </summary>
    public class EditSiteModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Numéro télé transmeteur
        /// </summary>
        public string TransmitterNumber { get; set; }

        /// <summary>
        /// Nom du site
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type 
        /// </summary>
        public LabelIdModel<int> Type { get; set; }

        /// <summary>
        /// Id du modèle de rapport
        /// </summary>
        public LabelIdModel<string> ReportModel { get; set; }

        /// <summary>
        /// Adresse 
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// true: Indique si il s'agit d'une adresse Google, false : adresse manuelle
        /// </summary>
        public bool AddressType { get; set; }

        /// <summary>
        /// Prix max d'intervention
        /// </summary>
        public float MaxInterventionCost { get; set; }

        /// <summary>
        /// Délais max d'intervention
        /// </summary>
        public float MaxDelay { get; set; }

        /// <summary>
        /// Information de reconnaissance du site
        /// </summary>
        public EditSiteRecognition Recognition { get; set; }

        /// <summary>
        /// Information de facturation du site
        /// </summary>
        public SiteBillingAccountModel AccountBilling { get; set; }

        /// <summary>
        /// Notes, commentaires ...
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Liste des contacts
        /// </summary>
        public List<Contact> Contacts { get; set; }

        /// <summary>
        /// Type de notification 
        /// </summary>
        public LabelIdModel<int> GroupNotify { get; set; }

        /// <summary>
        /// Liste des instructions
        /// </summary>
        public List<LabelListModel<int, object, List<string>>> Instructions { get; set; }
    }
}