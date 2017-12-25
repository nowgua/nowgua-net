using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Configurations
{
    /// <summary>
    /// Information de connexion au moteur de recherche nowgua
    /// </summary>
    public class ElasticSearchConfiguration
    {
        public string ConnectionString { get; set; }
        public string Index { get; set; }
    }
}
