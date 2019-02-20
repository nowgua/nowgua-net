using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Models
{
    /// <summary>
    /// Id + Label
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LabelModel<T>
    {
        public T Id { get; set; }
        public string Label { get; set; }

		public LabelModel(T Id, string Label)
		{
			this.Id = Id;
			this.Label = Label;
		}

	}
}
