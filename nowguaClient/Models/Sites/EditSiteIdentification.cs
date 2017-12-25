using System.Collections.Generic;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Modèle de modification des informations de reconnaissance du site 
    /// </summary>
    public class EditSiteRecognition
    {
        /// <summary>
        /// Liste des images
        /// </summary>
        public List<string> Pictures { get; set; }

        /// <summary>
        /// Moyen d'accès 
        /// </summary>
        public string Access { get; set; }

        /// <summary>
        /// Informations sur les issues 
        /// </summary>
        public string ExitInformations { get; set; }
    }
}