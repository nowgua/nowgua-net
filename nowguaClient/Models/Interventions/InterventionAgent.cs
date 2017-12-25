using nowguaClient.Models.Users;

namespace nowguaClient.Models.Interventions
{
    /// <summary>
    /// Utilisateur Agent de l'intervention
    /// </summary>
    public class InterventionAgent
    {
        /// <summary>
        /// Id de l'utilisateur Agent
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nom complet
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Prénom
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nom
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Téléphone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Société de l'utilisateur
        /// </summary>
        public UserCompanyModel Company { get; set; }
    }
}