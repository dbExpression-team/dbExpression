using System.Collections.Generic;

namespace DbExpression.CodeTemplating.Model
{
    public class FiltersTemplateModel
    {
        public IList<FilterOperationsTemplateModel> ThisTypeOnlyFilters { get; set; } = new List<FilterOperationsTemplateModel>();
        public IList<FilterOperationsTemplateModel> AllDataTypeFilters { get; set; } = new List<FilterOperationsTemplateModel>();
    }
}
