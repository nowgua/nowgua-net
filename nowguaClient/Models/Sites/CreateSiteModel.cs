using nowguaClient.Models.ACLsModel;
using nowguaClient.Models.Interventions;
using System.Collections.Generic;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Modèle de création d'un site
    /// </summary>
    public class CreateSiteModel
    {
        /// <summary>
        /// Numéro télé transmeteur
        /// </summary>
        public string TransmitterNumber { get; set; }

        /// <summary>
        /// Nom du site
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type de site
        /// </summary>
        public LabelIdModel<int> Type { get; set; }

        /// <summary>
        /// Modèle de rapport
        /// </summary>
        public LabelIdModel<string> ReportModel { get; set; }

		/// <summary>
		/// Modèle de Groupe de site
		/// </summary>
		public LabelIdModel<string> GroupSiteId { get; set; }

		/// <summary>
		/// Adresse du site
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
        public Contacts Contacts { get; set; }

        /// <summary>
        /// Type de notification 
        /// </summary>
        public LabelIdModel<int> GroupNotify { get; set; }

        /// <summary>
        /// Liste des instructions
        /// </summary>
        public CreateInstructionModel Instructions { get; set; }

        /// <summary>
        /// Liste des sociétés en copie des rapports 
        /// </summary>
        public List<string> CompanyReceiptReport { get; set; }

        /// <summary>
        /// Sociétés qui peuvent accéder au site
        /// </summary>
        public List<EditACLModel> CompanyACLs { get; set; }

        /// <summary>
        /// Equipes qui peuvent accéder au site
        /// </summary>
        public List<EditACLModel> TeamACLs { get; set; }

        /// <summary>
        /// Moyens d'accès
        /// </summary>
        public SiteAccessInformation AccessInformation { get; set; }

        /// <summary>
        /// Création d'un site 
        /// </summary>
        /// <param name="Name">Nom du site</param>
        /// <param name="TransmitterNumber">Numéro télé-transmeteur</param>
        /// <param name="Type">Identifiant correspondant au type de site. consulter https://nowgua-prod-api.azurewebsites.net/swagger/ui/#!/AppSettings/Api1_0AppsettingsGet pour plus d'information</param>
        public CreateSiteModel(string Name, string TransmitterNumber, int Type)
        {
            this.Type = new LabelIdModel<int>();
            this.ReportModel = new LabelIdModel<string>();
            this.Recognition = new EditSiteRecognition();
            this.AccountBilling = new SiteBillingAccountModel();
            this.Contacts = new Contacts();
            this.GroupNotify = new LabelIdModel<int>();
            this.Instructions = new CreateInstructionModel();
            this.CompanyReceiptReport = new List<string>();
            this.CompanyACLs = new List<EditACLModel>();
            this.TeamACLs = new List<EditACLModel>();
            this.AccessInformation = new SiteAccessInformation();
		
            this.Name = Name;
            this.TransmitterNumber = TransmitterNumber;
            this.GroupNotify.Id = 1;
            this.AccountBilling.SiteBA = false;
            this.Type.Id = Type;
        }
    }

    /// <summary>
    /// Modèle de création d'instructions
    /// </summary>
    public class CreateInstructionModel : List<LabelListModel<int, object, List<string>>>
    {
        /// <summary>
        /// Ajout d'une instruction 
        /// Pour consulter la liste des différentes inscriptions consulter la page suivante 
        /// https://nowgua-prod-api.azurewebsites.net/swagger/ui/#!/AppSettings/Api1_0AppsettingsGet
        /// </summary>
        /// <param name="InstructionId">Identifiant correspondant au type d'instruction</param>
        /// <param name="Value">Valeur de l'instruction : string, boolean etc ...</param>
        public void Add(int InstructionId, object Value)
        {
            this.Add(new LabelListModel<int, object, List<string>> { Id = InstructionId, Value = Value.ToString() });
        }
    }

    /// <summary>
    /// Modèle de contacts
    /// </summary>
    public class Contacts : List<Contact>
    {
        /// <summary>
        /// Ajout d'un contact
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        /// <param name="RapportMail"></param>
        public void Add(string FirstName, string LastName, string Email , string Phone, bool RapportMail)
        {
            this.Add(new Contact { FirstName = FirstName, LastName = LastName, Email = Email, Phone = Phone, RapportMail = RapportMail });
        }
    }
}
