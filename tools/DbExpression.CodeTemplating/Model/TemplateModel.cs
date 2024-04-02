using System.Collections.Generic;

namespace DbExpression.CodeTemplating.Model
{
    public class TemplateModel
    {
        public IList<string> Usings { get; set; } = new List<string>();
        public string? Namespace { get; set; }
        public TypeModel? Type { get; set; }
        public IList<ArithmeticOperationsTemplateModel> ArithmeticOperations { get; set; } = new List<ArithmeticOperationsTemplateModel>();
        public FiltersTemplateModel Filters { get; set; } = new FiltersTemplateModel();
    }
}
