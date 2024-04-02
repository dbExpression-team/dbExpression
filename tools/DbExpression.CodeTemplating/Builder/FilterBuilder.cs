using DbExpression.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DbExpression.CodeTemplating.Builder
{
    public class FilterBuilder
    {
        private static readonly FilterOperationTemplateModel equal = new() { FilterOperatorName = "Equal", FilterOperatorSymbol = "==" };
        private static readonly FilterOperationTemplateModel notEqual = new() { FilterOperatorName = "NotEqual", FilterOperatorSymbol = "!=" };
        private static readonly FilterOperationTemplateModel lessThan = new() { FilterOperatorName = "LessThan", FilterOperatorSymbol = "<" };
        private static readonly FilterOperationTemplateModel lessThanOrEqual = new() { FilterOperatorName = "LessThanOrEqual", FilterOperatorSymbol = "<=" };
        private static readonly FilterOperationTemplateModel greaterThan = new() { FilterOperatorName = "GreaterThan", FilterOperatorSymbol = ">" };
        private static readonly FilterOperationTemplateModel greaterThanOrEqual = new() { FilterOperatorName = "GreaterThanOrEqual", FilterOperatorSymbol = ">=" };

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
            => new();

        public FilterBuilder InferFilterOperations(TypeModel sourceType, TypeModel targetType)
        {
            var equalityOnly = TypeBuilder.CreateBuilder().Add<bool>().Add<Guid>().ToList();

            if (equalityOnly.Contains(sourceType) && equalityOnly.Contains(targetType))
            {
                if (sourceType != targetType)
                {
                    operations = new List<FilterOperationTemplateModel>();
                    return this;
                }
                operations = new List<FilterOperationTemplateModel>
                {
                    equal,
                    notEqual
                };
                return this;
            }
            if (equalityOnly.Contains(sourceType) || equalityOnly.Contains(targetType))
            {
                //can't compare anything to bool or Guid
                operations = new List<FilterOperationTemplateModel>();
                return this;
            }

            if (sourceType.Type == typeof(string) || targetType.Type == typeof(string))
            {
                if (sourceType.Type != typeof(string) || targetType.Type != typeof(string))
                {
                    //can't compare anything to string
                    operations = new List<FilterOperationTemplateModel>();
                    return this;
                }
                operations = new List<FilterOperationTemplateModel>
                {
                    equal,
                    notEqual,
                    lessThan,
                    greaterThan,
                    lessThanOrEqual,
                    greaterThanOrEqual
                };
                return this;
            }

            if (targetType.Type == typeof(object) || sourceType.Type == typeof(object))
            {
                //assume they can be compared, not the compiler's issue to determine if these comparisons can occur
                operations = new List<FilterOperationTemplateModel>
                {
                    equal,
                    notEqual,
                    lessThan,
                    greaterThan,
                    lessThanOrEqual,
                    greaterThanOrEqual
                };
                return this;
            }

            var numerics = TypeBuilder.CreateBuilder().AddNumericTypes().ToList();
            if (numerics.Contains(sourceType) && numerics.Contains(targetType))
            {
                operations = new List<FilterOperationTemplateModel>
                {
                    equal,
                    notEqual,
                    lessThan,
                    greaterThan,
                    lessThanOrEqual,
                    greaterThanOrEqual
                };
                return this;
            }

            var dates = TypeBuilder.CreateBuilder().AddDateTypes().ToList();
            if (dates.Contains(sourceType) && dates.Contains(targetType))
            {
                operations = new List<FilterOperationTemplateModel>
                {
                    equal,
                    notEqual,
                    lessThan,
                    greaterThan,
                    lessThanOrEqual,
                    greaterThanOrEqual
                };
                return this;
            }

            if (targetType == sourceType)
            {
                operations = new List<FilterOperationTemplateModel>
                {
                    equal,
                    notEqual,
                };
                return this;
            }
            operations = new List<FilterOperationTemplateModel>();
            return this;





            //if (sourceType == TypeBuilder.Get<string>())
            //{
            //    if (targetType != TypeBuilder.Get<string>())
            //    { 
            //        //can't compare a string to anything but a string
            //        operations = new List<FilterOperationTemplateModel>();
            //        return this;
            //    }

            //    operations = new List<FilterOperationTemplateModel>
            //    {
            //        equal,
            //        notEqual
            //    };

            //    return this;
            //}

            //if (targetType.Type.In(typeof(bool), typeof(Guid)) || sourceType.Type.In(typeof(bool), typeof(Guid)))
            //{
            //    operations = new List<FilterOperationTemplateModel>
            //    { 
            //        equal,
            //        notEqual
            //    };

            //    return this;
            //}

            //operations = new List<FilterOperationTemplateModel>
            //{
            //    equal,
            //    notEqual,
            //    lessThan,
            //    greaterThan,
            //    lessThanOrEqual,
            //    greaterThanOrEqual
            //};

            //return this;
        }
    }
}
