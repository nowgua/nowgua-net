using nowguaClient.Models.Files;
using System.Collections.Generic;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Information de reconnaissance du site
    /// </summary>
    public class SiteRecognitionModel
    {
        /// <summary>
        /// Images
        /// </summary>
        public List<FileModel> Pictures { get; set; }

        /// <summary>
        /// Moyen d'accès
        /// </summary>
        public string Access { get; set; }

        /// <summary>
        /// Informations sur les issues du site
        /// </summary>
        public string ExitInformations { get; set; }
    }
}