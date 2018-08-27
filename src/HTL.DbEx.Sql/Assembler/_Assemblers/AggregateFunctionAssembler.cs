using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HTL.DbEx.Sql.Assembler
{
    public class AggregateFunctionAssembler :
        ISqlPartAssembler<DBAggregateFunctionExpression>
    {
        private static IDictionary<DBAggregateFunction, string> _aggregateFunctionMap;
        private static IDictionary<DBAggregateFunction, string> AggregateFunctionMap => _aggregateFunctionMap ?? (_aggregateFunctionMap = typeof(DBAggregateFunction).GetValuesAndAggregateFunctions());

        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as DBAggregateFunctionExpression, builder, overrides);

        public string Assemble(DBAggregateFunctionExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => $"{AggregateFunctionMap[expressionPart.AggregateFunction]}({(expressionPart.Distinct ? " DISTINCT " : string.Empty)}{builder.AssemblePart(expressionPart.Expression, overrides)})";
    }
}
