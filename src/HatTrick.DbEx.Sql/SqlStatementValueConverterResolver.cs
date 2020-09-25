using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql
{

    public class SqlStatementValueConverterResolver : IValueConverterFinder
    {
        #region internals
        private readonly IEnumerable<FieldExpression> fieldExpressions;
        private readonly IValueConverterFactory valueConverterFactory;
        #endregion

        #region constructors
        public SqlStatementValueConverterResolver(IEnumerable<FieldExpression> fieldExpressions, IValueConverterFactory valueConverterFactory)
        {
            this.fieldExpressions = fieldExpressions ?? throw new ArgumentNullException($"{nameof(fieldExpressions)} is required.");
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException($"{nameof(valueConverterFactory)} is required.");
        }

        public SqlStatementValueConverterResolver(IEnumerable<ParameterizedFieldExpression> fieldExpressions, IValueConverterFactory valueConverterFactory)
        {
            if (fieldExpressions is null)
                throw new ArgumentNullException($"{nameof(fieldExpressions)} is required.");
            this.fieldExpressions = fieldExpressions.Where(x => x.Field is object).Select(x => x.Field);
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException($"{nameof(valueConverterFactory)} is required.");
        }

        public SqlStatementValueConverterResolver(SelectExpressionSet selectExpressionSet, IValueConverterFactory valueConverterFactory)
        {
            if (selectExpressionSet is null)
                throw new ArgumentNullException($"{nameof(selectExpressionSet)} is required.");
            this.fieldExpressions = selectExpressionSet.Expressions.Select(x => x.Expression.Expression as FieldExpression);
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException($"{nameof(valueConverterFactory)} is required.");
        }
        #endregion

        #region methods
        public IValueConverter FindConverter(FieldExpression field)
            => field is object ? valueConverterFactory.CreateConverter(field) ?? valueConverterFactory.CreateConverter((field as IExpressionField).DeclaredType) : null;

        public IValueConverter FindConverter(Type declaredType)
            => valueConverterFactory.CreateConverter(declaredType);

        public IValueConverter FindConverter(int index)
            => FindConverter(fieldExpressions.ElementAt(index));
        #endregion
    }
}
