using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ArithmeticAppender :
        ExpressionAppender,
        IAssemblyPartAppender<ArithmeticExpression>
    {
        private static IDictionary<ArithmeticExpressionOperator, string> _arithmeticOperatorMap;
        private static IDictionary<ArithmeticExpressionOperator, string> ArithmeticOperatorMap => _arithmeticOperatorMap ?? (_arithmeticOperatorMap = typeof(ArithmeticExpressionOperator).GetValuesAndArithmeticOperators());

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as ArithmeticExpression, builder, context);

        public void AppendPart(ArithmeticExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (typeof(IComparable).IsAssignableFrom(expression.LeftPart.Item1))
            {
                if (expression.RightPart.Item2 is FieldExpression field)
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.LeftPart.Item2, field).Parameter.ParameterName);
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.LeftPart.Item2, expression.LeftPart.Item1).ParameterName);
                }
            }
            else
            {
                builder.AppendPart(expression.LeftPart, context);
            }

            builder.Appender.Write(ArithmeticOperatorMap[expression.ExpressionOperator]);

            if (typeof(IComparable).IsAssignableFrom(expression.RightPart.Item1))
            {
                if (expression.LeftPart.Item2 is FieldExpression field)
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.RightPart.Item2, field).Parameter.ParameterName);
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.RightPart.Item2, expression.RightPart.Item1).ParameterName);
                }
            }
            else
            {
                builder.AppendPart(expression.RightPart, context);
            }

            AppendAlias(expression, builder, context);
        }
    }
}
