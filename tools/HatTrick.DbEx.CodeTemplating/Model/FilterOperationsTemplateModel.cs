using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.CodeTemplating.Model
{
    public class FilterOperationsTemplateModel
    { 
        public TypeModel? Type { get; set; }
        public IList<FilterOperationTemplateModel> Operations { get; set; } = new List<FilterOperationTemplateModel>();
    }
}
