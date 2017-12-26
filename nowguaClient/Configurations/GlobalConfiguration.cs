using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Configurations
{
    /// <summary>
    /// Information de connexion au provider Identity
    /// </summary>
    public class GlobalConfiguration
    {
        public string BaseUrl = "https://nowga.eu.auth0.com/oauth/token";

        public string Audience { get; set; }
        public string ClientConnexion { get; set; }
        public string ElasticConnectionString { get; set; }
        public string ElasticIndex { get; set; }
    }

    public class AuthModel
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string audience { get; set; }
        public string grant_type { get; set; }

        public AuthModel(string ClientId, string ClientSecret, string Audience)
        {
            this.client_id = ClientId;
            this.client_secret = ClientSecret;
            this.audience = Audience;
            this.grant_type = "client_credentials";
        }
    }

    public class AuthToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}
