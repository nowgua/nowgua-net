using nowguaClient.Models.Files;
using nowguaClient.Models.Sites;
using System.Collections.Generic;

namespace nowguaClient.Models.Interventions
{
    /// <summary>
    /// Rapport
    /// </summary>
    public class ReportModel
    {
        /// <summary>
        /// Liste des images 
        /// </summary>
        public List<FileModel> Pictures { get; set; }

        /// <summary>
        /// Liste des vidéos
        /// </summary>
        public List<FileModel> Videos { get; set; }

        /// <summary>
        /// Liste des réponses au rapport
        /// </summary>
        public List<InstructionModel> Instructions { get; set; }

        /// <summary>
        /// Note, Commentaire de l'agent
        /// </summary>
        public string Note { get; set; }
    }
}