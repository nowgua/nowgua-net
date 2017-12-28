using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Models.WebHooks
{
    /// <summary>
    /// Message WebHook reçu 
    /// </summary>
    public class WebHookMessage
    {
        /// <summary>
        /// Type de webhook
        /// </summary>
        public WebHookType Type { get; set; }

        /// <summary>
        /// Date de création du message
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Nom du message
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Données sérialisées du message
        /// </summary>
        public string Datas { get; set; }

        /// <summary>
        /// Parsing du message
        /// </summary>
        /// <typeparam name="T">Type de Modèle cible</typeparam>
        /// <returns></returns>
        public T Parse<T>()
        {
            return JsonConvert.DeserializeObject<T>(this.Datas);
        }

        public WebHookMessage()
        {

        }
    }
}
