using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AggregateFunctionAppender :
        IAssemblyPartAppender<AggregateFunctionExpression>
    {
        #region internals
        private static IDictionary<AggregateFunction, string> _aggregateFunctionMap;
        private static IDictionary<AggregateFunction, string> AggregateFunctionMap => _aggregateFunctionMap ?? (_aggregateFunctionMap = typeof(AggregateFunction).GetValuesAndAggregateFunctions());
        #endregion

        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as AggregateFunctionExpression, builder, context);

        public void AppendPart(AggregateFunctionExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write(AggregateFunctionMap[expression.AggregateFunction])
                .Write("(");
            if (expression.Distinct)
                builder.Appender.Write("DISTINCT ");
            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
