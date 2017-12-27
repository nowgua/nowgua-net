using System;

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

        /// <summary>
        /// Création d'une intervention
        /// </summary>
        /// <param name="SiteId">Identifiant du site nowgua</param>
        /// <param name="AlarmType">Identifiant de l'alarme</param>
        /// <param name="AlarmDate">Date heure de l'alarme</param>
        /// <param name="Commentaire">Commentaire ou toutes autres informations pertinentes à transmettre</param>
        public CreateInterventionModel(string SiteId, int AlarmType, DateTime AlarmDate, string Commentaire = "")
        {
            TimeSpan elapsedTime = AlarmDate - new DateTime(1970, 1, 1, 0, 0, 0);
            this.AlarmDate = (long)elapsedTime.TotalMilliseconds;
            this.Site = new LabelIdModel<string> { Id = SiteId };
            this.AlarmType = new LabelIdModel<int> { Id =AlarmType };
            this.Commentaire = Commentaire;
            this.Radius = 60;
        }
    }
}