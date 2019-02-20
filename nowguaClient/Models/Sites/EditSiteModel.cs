using nowguaClient.Models;
using nowguaClient.Models.Interventions;
using System.Collections.Generic;
using System.Linq;

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
		/// Ancien Modèle de Groupe de site
		/// </summary>
		public List<LabelIdModel<string>> OldGroupSiteIds { get; set; }

		/// <summary>
		/// Modèle de Groupe de site
		/// </summary>
		public List<LabelIdModel<string>> GroupSiteIds { get; set; }

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
		/// Reference client
		/// </summary>
		public string RefClient { get; set; }

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
        public CreateInstructionModel Instructions { get; set; }

        /// <summary>
        /// Moyens d'accès
        /// </summary>
        public SiteAccessInformation AccessInformation { get; set; }

		/// <summary>
		/// Detection du perimetre
		/// </summary>
		public DetectionPerimeterType DetectionPerimeter { get; set; }

		/// <summary>
		/// Detection du perimetre
		/// </summary>
		public bool Incomplete { get; set; }

		public static implicit operator EditSiteModel(SiteModel Model)
        {
            EditSiteModel editModel = new EditSiteModel();
            editModel.Name = Model.Name;
            editModel.TransmitterNumber = Model.TransmitterNumber;
            editModel.Id = Model.Id;
            editModel.Type = new LabelIdModel<int> { Id = Model.Type.Id };
            editModel.Address = new Address(Model.Address.Text, Model.Address.Location.Lat, Model.Address.Location.Lon);
            editModel.AddressType = Model.AddressType;
            editModel.MaxInterventionCost = Model.MaxInterventionCost;
            editModel.MaxDelay = Model.MaxDelay;
            editModel.Recognition = new EditSiteRecognition { Access = Model.Recognition.Access, ExitInformations = Model.Recognition.ExitInformations, Pictures = Model.Recognition.Pictures.Select(p => p.Id).ToList() };
            editModel.AccountBilling = Model.AccountBilling;
            editModel.Notes = Model.Notes;
            editModel.Contacts = Model.Contacts;
            editModel.GroupNotify = new LabelIdModel<int> { Id = Model.GroupNotify.Id };
            editModel.AccessInformation = new SiteAccessInformation();
			editModel.DetectionPerimeter = Model.DetectionPerimeter;


            return editModel;
        }
    }
}