﻿using HatTrick.DbEx.Sql.Assembler;
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
        private readonly IEnumerable<IExpressionTypeProvider> fieldExpressions;
        private readonly IValueConverterFactory valueConverterFactory;
        #endregion

        #region constructors
        public SqlStatementValueConverterResolver(IEnumerable<FieldExpression> fieldExpressions, IValueConverterFactory valueConverterFactory)
        {
            this.fieldExpressions = fieldExpressions ?? throw new ArgumentNullException(nameof(fieldExpressions));
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
        }

        public SqlStatementValueConverterResolver(SelectExpressionSet selectExpressionSet, IValueConverterFactory valueConverterFactory)
        {
            if (selectExpressionSet is null)
                throw new ArgumentNullException(nameof(selectExpressionSet));
            this.fieldExpressions = selectExpressionSet.Expressions.Cast<IExpressionTypeProvider>();
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
        }
        #endregion

        #region methods
        public IValueConverter FindConverter(Type declaredType)
            => valueConverterFactory.CreateConverter(declaredType);

        public IValueConverter FindConverter(int index)
            =>  FindConverter(fieldExpressions.ElementAt(index));

        private IValueConverter FindConverter(IExpressionTypeProvider provider)
        {
            if (provider is null)
                return null;

            return valueConverterFactory.CreateConverter(provider.DeclaredType);
        }
        #endregion
    }
}
