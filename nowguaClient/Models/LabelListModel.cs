using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Models
{
    public class LabelListModel<TId, TValue, TList>
    {
        public TId Id { get; set; }
        public string Value { get; set; }
        public List<string> OptionValues { get; set; }

        public LabelListModel()
        {

        }

        public LabelListModel(TId Id, string Value, List<string> OptionValues)
        {
            this.Id = Id;
            this.Value = Value;
            this.OptionValues = OptionValues;
        }
    }
}