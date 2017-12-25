using nowguaClient.Models.ACLsModel;
using System.Linq;

namespace nowguaClient.Models.Interventions
{
    /// <summary>
    /// Modèle de log d'une intervention
    /// </summary>
    public class InterventionLogModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Timestamp du log
        /// </summary>
        public long Date { get; set; }

        /// <summary>
        /// Id de l'intervention
        /// </summary>
        public string InterventionId { get; set; }

        /// <summary>
        /// Numéro de l'intervention
        /// </summary>
        public long IDNumber { get; set; }

        /// <summary>
        /// Utilisateur qui a réalisé l'action
        /// </summary>
        public InterventionLogUserModel User { get; set; }

        /// <summary>
        /// Type d'action
        /// </summary>
        public LabelModel<int> Action { get; set; }

        /// <summary>
        /// Niveau du log
        /// </summary>
        public LabelModel<int> Level { get; set; }

        /// <summary>
        /// Message du log
        /// </summary>
        public string Message { get; set; }

        public InterventionLogModel()
        {

        }
    }

    /// <summary>
    /// Utilisateur du log
    /// </summary>
    public class InterventionLogUserModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
    }
}
