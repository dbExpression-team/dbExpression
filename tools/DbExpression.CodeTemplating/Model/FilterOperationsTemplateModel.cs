using System;
using System.Collections.Generic;

namespace DbExpression.CodeTemplating.Model
{
    public class FilterOperationsTemplateModel
    { 
        public TypeModel? Type { get; set; }
        public IList<FilterOperationTemplateModel> Operations { get; set; } = new List<FilterOperationTemplateModel>();
    }
}
