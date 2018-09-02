using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ArithmeticAssembler :
        IDbExpressionAssemblyPartAssembler<ArithmeticExpression>
    {
        private static IDictionary<ArithmeticExpressionOperator, string> _arithmeticOperatorMap;
        private static IDictionary<ArithmeticExpressionOperator, string> ArithmeticOperatorMap => _arithmeticOperatorMap ?? (_arithmeticOperatorMap = typeof(ArithmeticExpressionOperator).GetValuesAndArithmeticOperators());

        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as ArithmeticExpression, builder, overrides);

        public string Assemble(ArithmeticExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            string left = builder.AssemblePart(expressionPart.LeftPart, overrides);
            string right = typeof(IComparable).IsAssignableFrom(expressionPart.RightPart.Item1) ?
                builder.Parameters.Add(builder.FormatValueType(expressionPart.RightPart), expressionPart.RightPart.Item1).ParameterName
                :
                builder.AssemblePart(expressionPart.RightPart, overrides);

            return $"({left}{ArithmeticOperatorMap[expressionPart.ExpressionOperator]}{right})";
        }
    }
}
