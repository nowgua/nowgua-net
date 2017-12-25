namespace nowguaClient.Models.Files
{
    /// <summary>
    /// Fichier
    /// </summary>
    public class FileModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nom du fichier
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// ContentType
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Taille
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// Clé de consultation
        /// </summary>
        public string ViewTemporaryKey { get; set; }
    }
}