namespace nowguaClient.Models
{
    /// <summary>
    /// Modèle de création d'un webhook
    /// </summary>
    public class CreateWebHookModel
    {
        /// <summary>
        /// Type d'évènement : Incident ou Site
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// URL vers lequel sera posté l'évènement
        /// </summary>
        public string URL { get; set; }
    }
}