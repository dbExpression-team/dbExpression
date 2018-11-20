using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ArithmeticAppender :
        IAssemblyPartAppender<ArithmeticExpression>
    {
        private static IDictionary<ArithmeticExpressionOperator, string> _arithmeticOperatorMap;
        private static IDictionary<ArithmeticExpressionOperator, string> ArithmeticOperatorMap => _arithmeticOperatorMap ?? (_arithmeticOperatorMap = typeof(ArithmeticExpressionOperator).GetValuesAndArithmeticOperators());

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as ArithmeticExpression, builder, context);

        public void AppendPart(ArithmeticExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.AppendPart(expression.LeftPart, context);
            builder.Appender.Write(ArithmeticOperatorMap[expression.ExpressionOperator]);
            if (typeof(IComparable).IsAssignableFrom(expression.RightPart.Item1))
            {
                builder.Appender.Write(builder.Parameters.Add(builder.FormatValueType(expression.RightPart), expression.RightPart.Item1).ParameterName);
            }
            else
            {
                builder.AppendPart(expression.RightPart, context);
            }
        }
    }
}
