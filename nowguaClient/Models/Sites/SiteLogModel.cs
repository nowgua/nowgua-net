using System.Linq;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Information de traçabilité d'un site
    /// </summary>
    public class SiteLogModel
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Timestamp du log
        /// </summary>
        public long Date { get; set; }

        /// <summary>
        /// Utilisateur de l'action
        /// </summary>
        public SiteLogUserModel User { get; set; }

        /// <summary>
        /// Type d'action
        /// </summary>
        public LabelModel<int> Action { get; set; }

        /// <summary>
        /// Niveau du log
        /// </summary>
        public LabelModel<int> Level { get; set; }

        /// <summary>
        /// Message 
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// User de l'action du log
    /// </summary>
    public class SiteLogUserModel
    {
        /// <summary>
        /// Id de l'utilisateur
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nom complet de l'utilisateu
        /// </summary>
        public string FullName { get; set; }
    }
}