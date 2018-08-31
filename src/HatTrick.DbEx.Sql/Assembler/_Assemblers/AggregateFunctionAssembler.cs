using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AggregateFunctionAssembler :
        IDbExpressionAssemblyPartAssembler<AggregateFunctionExpression>
    {
        private static IDictionary<AggregateFunction, string> _aggregateFunctionMap;
        private static IDictionary<AggregateFunction, string> AggregateFunctionMap => _aggregateFunctionMap ?? (_aggregateFunctionMap = typeof(AggregateFunction).GetValuesAndAggregateFunctions());

        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as AggregateFunctionExpression, builder, overrides);

        public string AssemblePart(AggregateFunctionExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => $"{AggregateFunctionMap[expressionPart.AggregateFunction]}({(expressionPart.Distinct ? " DISTINCT " : string.Empty)}{builder.AssemblePart(expressionPart.Expression, overrides)})";
    }
}
