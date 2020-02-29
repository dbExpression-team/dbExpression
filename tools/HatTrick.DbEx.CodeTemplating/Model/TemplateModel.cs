using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.CodeTemplating.Model
{
    public class TemplateModel
    {
        public IList<string> Usings { get; set; } = new List<string>();
        public string Namespace { get; set; }
        public TypeModel Type { get; set; }
        public bool IsOrderBySupported { get; set; } = true;
        public bool IsGroupBySupported { get; set; } = true;
        public IList<ArithmeticOperationsTemplateModel> ArithmeticOperations { get; set; } = new List<ArithmeticOperationsTemplateModel>();
        public IList<FilterOperationTemplateModel> FilterOperations { get; set; } = new List<FilterOperationTemplateModel>();
    }
}
