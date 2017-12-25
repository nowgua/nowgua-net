using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Configurations
{
    /// <summary>
    /// Information de connexion à l'API nowgua
    /// </summary>
    public class NowguaConnectionSettings
    {
        /// <summary>
        /// ClientId
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// ClientSecret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// URL de l'API Nowgua
        /// </summary>
        public string ApiBaseURL { get; set; }

        public NowguaConnectionSettings(string ApiBaseURL, string ClientId, string ClientSecret)
        {
            this.ApiBaseURL = ApiBaseURL;
            this.ClientId = ClientId;
            this.ClientSecret = ClientSecret;
        }
    }

    /// <summary>
    /// Information de configuration nowgua
    /// </summary>
    public class NowguaConfiguration
    {
        public ElasticSearchConfiguration ElasticSearch { get; set; }
        public AuthConfiguration Auth { get; set; }
    }
}