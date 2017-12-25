using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Models
{
    /// <summary>
    /// Id sous forme d'objet
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LabelIdModel<T>
    {
        public T Id { get; set; }
    }
}