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
		/// true: si Nowgua est le createur du site, false: si Nowgua n'est pas le createur du site
		/// </summary>
		public bool OwnerNowgua { get; set; }

		/// <summary>
		/// Type de site
		/// </summary>
		public LabelModel<int> Type { get; set; }

		/// <summary>
		/// Modèle de Groupe de site
		/// </summary>
		public List<GroupSiteModel> GroupSiteIds { get; set; }

		/// <summary>
		/// Id du modèle de rapport
		/// </summary>
		public NameModel<string> ReportModel { get; set; }

		/// <summary>
		/// Adresse du site
		/// </summary>
		public AddressModel Address { get; set; }

        /// <summary>
        /// true: Indique si il s'agit d'une adresse Google, false : adresse manuelle
        /// </summary>
        public bool AddressType { get; set; }

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
		/// Reference client
		/// </summary>
		public string RefClient { get; set; }

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

        /// <summary>
        /// Moyens d'accès
        /// </summary>
        public SiteAccessInformation AccessInformation { get; set; }

		/// <summary>
		/// Detection du perimetre
		/// </summary>
		public DetectionPerimeterType DetectionPerimeter { get; set; }

		public bool Incomplete { get; set; }

		/// <summary>
		/// Indicateur de suppression
		/// </summary>
		public bool Deleted { get; set; }

		/// <summary>
		/// Date de suppression
		/// </summary>
		public long DeletedDate { get; set; }

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
