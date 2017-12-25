namespace nowguaClient.Models.Users
{
    /// <summary>
    /// Utilisateur connecté
    /// </summary>
    public class UserMeModel : UserModel
    {
        /// <summary>
        /// Mot de passe ELK
        /// </summary>
        public string ELKPassword { get; set; }

        public UserMeModel()
            :base()
        {

        }
    }
}