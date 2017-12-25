namespace nowguaClient.Models
{
    /// <summary>
    /// WebHook
    /// </summary>
    public class WebHookModel
    {
        /// <summary>
        /// Identifiant du webhook
        /// </summary>
        public string Id { get; set; }

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