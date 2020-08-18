using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Converter
{
    public class FieldExpressionConverters
    {
        private readonly IEnumerable<FieldExpression> set;
        private readonly IValueConverterFactory converters;

        public FieldExpressionConverters(IEnumerable<FieldExpression> set, IValueConverterFactory converters)
        {
            this.set = set;
            this.converters = converters;
        }

        public FieldExpressionConverters(SelectExpressionSet set, IValueConverterFactory converters)
        {
            this.set = new List<FieldExpression>(set.Expressions.Select(x => x.Expression.Expression as FieldExpression));
            this.converters = converters;
        }

        public IValueConverter this[FieldExpression field]
        {
            get
            {
                if (field is null)
                    return converters.CreateConverter();

                var fieldExpression = set.FirstOrDefault(x => x == field);
                return fieldExpression is object ? converters.CreateConverter(fieldExpression) : converters.CreateConverter();
            }
        }

        public IValueConverter this[int index]
        {
            get
            {
                var fieldExpression = set.ElementAt(index);
                return fieldExpression is object ? converters.CreateConverter(fieldExpression) : converters.CreateConverter();
            }
        }
    }
}
