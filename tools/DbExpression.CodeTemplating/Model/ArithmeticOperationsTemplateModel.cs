using System;
using System.Collections.Generic;
using System.Text;

namespace DbExpression.CodeTemplating.Model
{
    public class ArithmeticOperationsTemplateModel
    {
        public TypeModel? OperationType { get; set; }
        public TypeModel? ReturnType { get; set; }
        public IList<ArithmeticOperationTemplateModel> Operations { get; set; } = new List<ArithmeticOperationTemplateModel>();
    }
}
