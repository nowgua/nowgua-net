namespace nowguaClient.Models.Users
{
    /// <summary>
    /// Information sur la société de l'utilisateur
    /// </summary>
    public class UserCompanyModel
    {
        /// <summary>
        /// Identifiant de la société
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nom de la société
        /// </summary>
        public string Name { get; set; }

        public UserCompanyModel()
        {

        }
    }
}