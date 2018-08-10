using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HTL.DbEx.Sql.Assembler
{
    public class ArithmeticAssembler :
        ISqlPartAssembler<DBArithmeticExpression>
    {
        private static IDictionary<DBArithmeticExpressionOperator, string> _arithmeticOperatorMap;
        private static IDictionary<DBArithmeticExpressionOperator, string> ArithmeticOperatorMap => _arithmeticOperatorMap ?? (_arithmeticOperatorMap = typeof(DBArithmeticExpressionOperator).GetValuesAndArithmeticOperators());

        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble(expressionPart as DBArithmeticExpression, builder);

        public string Assemble(DBArithmeticExpression expressionPart, ISqlStatementBuilder builder)
        {
            string left = builder.AssemblePart(expressionPart.LeftPart);
            string right = typeof(IComparable).IsAssignableFrom(expressionPart.RightPart.Item1) ?
                builder.Parameters.Add(builder.FormatValueType(expressionPart.RightPart), expressionPart.RightPart.Item1).ParameterName
                :
                builder.AssemblePart(expressionPart.RightPart);

            return $"({left}{ArithmeticOperatorMap[expressionPart.ExpressionOperator]}{right})";
        }
    }
}
