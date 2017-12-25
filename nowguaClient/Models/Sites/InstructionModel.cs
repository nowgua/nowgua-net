using System.Collections.Generic;
using System.Linq;

namespace nowguaClient.Models.Sites
{
    /// <summary>
    /// Instruction
    /// </summary>
    public class InstructionModel 
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Catégorie
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Valeur 
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Options possibles
        /// </summary>
        public List<string> OptionValues { get; set; }

        public InstructionModel(InstructionCategoryEnum Category
                                , int Id, string Label, InstructionTypeEnum Type, string Description, object Value, List<string> OptionValues)
        {
            this.Id = Id;
            this.Label = Label;
            this.Value = Value;
            this.Type = Type.ToString();
            this.Category = Category.ToString();
            this.Description = Description;
            this.OptionValues = OptionValues;
        }

        public InstructionModel()
        {

        }
    }

    /// <summary>
    /// Type d'instruction
    /// </summary>
    public enum InstructionTypeEnum
    {
        Boolean,
        Password,
        TextArea,
        Text,
        SingleChoice,
        MultiChoice
    }

    /// <summary>
    /// Catégorie d'instruction
    /// </summary>
    public enum InstructionCategoryEnum
    {
        Site,
        Intervention
    }
}