using System.Collections.Generic;
using nowguaClient.Models.Users;
using nowguaClient.Models.Sites;

namespace nowguaClient.Models.Interventions
{
    /// <summary>
    /// Intervention
    /// </summary>
    public class InterventionModel 
    {
        /// <summary>
        /// Id 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Numéro de l'intervention
        /// </summary>
        public long IDNumber { get; set; }

        /// <summary>
        /// Commentaire 
        /// </summary>
        public string Commentaire { get; set; }

        /// <summary>
        /// Créateur (timestamp)
        /// </summary>
        public UserModel CreatedUser { get; set; }

        /// <summary>
        /// Création (timestamp)
        /// </summary>
        public long CreationDate { get; set; }

        /// <summary>
        /// Début intervention (timestamp)
        /// </summary>
        public long BeginInterventionDate { get; set; }

        /// <summary>
        /// En route vers le site (timestamp)
        /// </summary>
        public long OnTheWayToSiteDate { get; set; }

        /// <summary>
        /// Arrivé sur site (timestamp)
        /// </summary>
        public long OnSiteDate { get; set; }

        /// <summary>
        /// Fin d'intervention (timestamp)
        /// </summary>
        public long EndInterventionDate { get; set; }

        /// <summary>
        /// A valider (timestamp)
        /// </summary>
        public long ToValidate { get; set; }

        /// <summary>
        /// Cloture (timestamp)
        /// </summary>
        public long CloseDate { get; set; }

        /// <summary>
        /// Annulation (timestamp)
        /// </summary>
        public long CancelDate { get; set; }

        /// <summary>
        /// Alarme (timestamp)
        /// </summary>
        public long AlarmDate { get; set; }

        /// <summary>
        /// Confirmation (timestamp)
        /// </summary>
        public long ConfirmDate { get; set; }

        /// <summary>
        /// Raison de l'annulation
        /// </summary>
        public string CancellationReason { get; set; }

        /// <summary>
        /// Utilisateur qui a annulé
        /// </summary>
        public UserModel CancellationUser { get; set; }

        /// <summary>
        /// Site de l'intervention
        /// </summary>
        public SiteModel Site { get; set; }
        
        /// <summary>
        /// Agent de sécurité
        /// </summary>
        public InterventionAgent SecurityAgent { get; set; }

        /// <summary>
        /// Etat de l'intervention
        /// </summary>
        public LabelModel<int> Status { get; set; }

        /// <summary>
        /// Type d'alarme
        /// </summary>
        public LabelModel<int> AlarmType { get; set; }

        /// <summary>
        /// Rapport de l'intervention
        /// </summary>
        public ReportModel Report { get; set; }

        /// <summary>
        /// Liste des annomalies
        /// </summary>
        public List<LabelModel<int>> Anomalies { get; set; }

        /// <summary>
        /// Validé ou non 
        /// </summary>
        public bool Validated { get; set; }

        /// <summary>
        /// Raison de non validation 
        /// </summary>
        public string NotValidateReason { get; set; }

        /// <summary>
        /// Niveau de satisfaction 
        /// </summary>
        public LabelModel<int> SatisfactionId { get; set; }

        /// <summary>
        /// Commentaire de satisfaction 
        /// </summary>
        public string SatisfactionCommentaire { get; set; }

        /// <summary>
        /// Note Additionnelle
        /// </summary>
        public string additionalNoteReport { get; set; }

        public InterventionModel()
        {

        }
    }
}