using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ArithmeticExpressionPartAppender : PartAppender<ArithmeticExpression>
    {
        private static IDictionary<ArithmeticExpressionOperator, string> _arithmeticOperatorMap;
        private static IDictionary<ArithmeticExpressionOperator, string> ArithmeticOperatorMap => _arithmeticOperatorMap ?? (_arithmeticOperatorMap = typeof(ArithmeticExpressionOperator).GetValuesAndArithmeticOperators());

        public override void AppendPart(ArithmeticExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("(");

            //left part of arithmetic operation
            if (typeof(IComparable).IsAssignableFrom(expression.LeftPart.Type))
            {
                //left part is primitive type, build a parameter for the primitive
                if (expression.RightPart.Object is FieldExpression field)
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.LeftPart.Object, field).Parameter.ParameterName);
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.LeftPart.Object, expression.LeftPart.Type).ParameterName);
                }
            }
            else
            {
                //left part isn't a primitive type, append using builder
                builder.AppendPart(expression.LeftPart, context);
            }

            //append the operator
            builder.Appender.Write(ArithmeticOperatorMap[expression.ExpressionOperator]);

            //right part of arithmetic operation
            if (typeof(IComparable).IsAssignableFrom(expression.RightPart.Type))
            {
                //right part is primitive type, build a parameter for the primitive
                if (expression.LeftPart.Object is FieldExpression field)
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.RightPart.Object, field).Parameter.ParameterName);
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.RightPart.Object, expression.RightPart.Type).ParameterName);
                }
            }
            else
            {
                //right part isn't a primitive type, append using builder
                builder.AppendPart(expression.RightPart, context);
            }

            builder.Appender.Write(")");
        }
    }
}
