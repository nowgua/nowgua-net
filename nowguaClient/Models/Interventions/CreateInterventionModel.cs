namespace nowguaClient.Models.Interventions
{
    /// <summary>
    /// Modèle de création d'une intervention
    /// </summary>
    public class CreateInterventionModel
    {
        /// <summary>
        /// Site de l'intervention 
        /// </summary>
        public LabelIdModel<string> Site { get; set; }

        /// <summary>
        /// Type d'alarme
        /// </summary>
        public LabelIdModel<int> AlarmType { get; set; }

        /// <summary>
        /// Date de l'alarme
        /// </summary>
        public long AlarmDate { get; set; }

        /// <summary>
        /// Agent de sécurité à qui on affectera l'intervention (non obligatoire)
        /// </summary>
        public LabelIdModel<string> SecurityAgent { get; set; }

        /// <summary>
        /// Commentaire
        /// </summary>
        public string Commentaire { get; set; }

        /// <summary>
        /// Rayon de recherche des agents (en km)
        /// </summary>
        public long Radius { get; set; }
    }
}