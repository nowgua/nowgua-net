using nowguaClient.Models.ACLsModel;
using System.Collections.Generic;
using System.Linq;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Site
    /// </summary>
    public class SiteModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Numéro télé-transmeteur
        /// </summary>
        public string TransmitterNumber { get; set; }

        /// <summary>
        /// Nom du site
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type de site
        /// </summary>
        public LabelModel<int> Type { get; set; }

        /// <summary>
        /// Adresse du site
        /// </summary>
        public AddressModel Address { get; set; }

        /// <summary>
        /// Prix Max de l'intervention
        /// </summary>
        public float MaxInterventionCost { get; set; }

        /// <summary>
        /// Délais Max d'intervention
        /// </summary>
        public float MaxDelay { get; set; }

        /// <summary>
        /// Information de reconnaissance 
        /// </summary>
        public SiteRecognitionModel Recognition { get; set; }

        /// <summary>
        /// Information de facturation du site
        /// </summary>
        public SiteBillingAccountModel AccountBilling { get; set; }

        /// <summary>
        /// Note ou commentaire 
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Liste des contacts du site
        /// </summary>
        public List<Contact> Contacts { get; set; }

        /// <summary>
        /// Type de notification du site
        /// </summary>
        public LabelModel<int> GroupNotify { get; set; }

        /// <summary>
        /// Instructions d'intervention du site
        /// </summary>
        public List<InstructionModel> Instructions { get; set; }

        /// <summary>
        /// Liste des sociétés qui veulent recevoir le rapport
        /// </summary>
        public List<string> CompanyReceiptReport { get; set; }

        /// <summary>
        /// Sociétés à qui l'accès du site est partagé
        /// </summary>
        public CompanyACLs CompanyACLs { get; set; }

        /// <summary>
        /// Equipes à qui l'accès du site est partagé
        /// </summary>
        public TeamACLs TeamACLs { get; set; }

        public SiteModel()
        {
            CompanyACLs = new CompanyACLs();
            TeamACLs = new TeamACLs();
        }
    }

    /// <summary>
    /// Contact d'un site
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Prénom
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nom
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Téléphone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Indique si le contact recevra le rapport de l'intervention par mail
        /// </summary>
        public bool RapportMail { get; set; }
    }
}