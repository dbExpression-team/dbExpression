using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.DbEx.CodeTemplating.Builder
{
    public class FilterBuilder
    {
        private static readonly FilterOperationTemplateModel equal = new FilterOperationTemplateModel { FilterOperatorName = "Equal", FilterOperatorSymbol = "==" };
        private static readonly FilterOperationTemplateModel notEqual = new FilterOperationTemplateModel { FilterOperatorName = "NotEqual", FilterOperatorSymbol = "!=" };
        private static readonly FilterOperationTemplateModel lessThan = new FilterOperationTemplateModel { FilterOperatorName = "LessThan", FilterOperatorSymbol = "<" };
        private static readonly FilterOperationTemplateModel lessThanOrEqual = new FilterOperationTemplateModel { FilterOperatorName = "LessThanOrEqual", FilterOperatorSymbol = "<=" };
        private static readonly FilterOperationTemplateModel greaterThan = new FilterOperationTemplateModel { FilterOperatorName = "GreaterThan", FilterOperatorSymbol = ">" };
        private static readonly FilterOperationTemplateModel greaterThanOrEqual = new FilterOperationTemplateModel { FilterOperatorName = "GreaterThanOrEqual", FilterOperatorSymbol = ">=" };

        private IList<FilterOperationTemplateModel> operations = new List<FilterOperationTemplateModel>();

        public FilterBuilder AddAll()
        {
            AddEqual();
            AddNotEqual();
            AddLessThan();
            AddLessThanOrEqual();
            AddGreaterThan();
            AddGreaterThanOrEqual();
            return this;
        }

        public FilterBuilder AddEqual()
        {
            if (!operations.Contains(equal))
                operations.Add(equal);
            return this;
        }

        public FilterBuilder AddNotEqual()
        {
            if (!operations.Contains(notEqual))
                operations.Add(notEqual);
            return this;
        }

        public FilterBuilder AddLessThan()
        {
            if (!operations.Contains(lessThan))
                operations.Add(lessThan);
            return this;
        }

        public FilterBuilder AddLessThanOrEqual()
        {
            if (!operations.Contains(lessThanOrEqual))
                operations.Add(lessThanOrEqual);
            return this;
        }

        public FilterBuilder AddGreaterThan()
        {
            if (!operations.Contains(greaterThan))
                operations.Add(greaterThan);
            return this;
        }

        public FilterBuilder AddGreaterThanOrEqual()
        {
            if (!operations.Contains(greaterThanOrEqual))
                operations.Add(greaterThanOrEqual);
            return this;
        }

        public IList<FilterOperationTemplateModel> ToList() => operations;

        public static FilterBuilder CreateBuilder()
            => new FilterBuilder();
    }
}
