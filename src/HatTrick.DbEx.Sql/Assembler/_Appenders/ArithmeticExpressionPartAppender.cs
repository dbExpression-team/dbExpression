using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ArithmeticExpressionPartAppender : PartAppender<ArithmeticExpression>
    {
        private static IDictionary<ArithmeticExpressionOperator, string> _arithmeticOperatorMap;
        private static IDictionary<ArithmeticExpressionOperator, string> ArithmeticOperatorMap => _arithmeticOperatorMap ?? (_arithmeticOperatorMap = typeof(ArithmeticExpressionOperator).GetValuesAndArithmeticOperators(x => string.IsNullOrWhiteSpace(x) ? " " : $" {x} "));

        public override void AppendPart(ArithmeticExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("(");

            //left part of arithmetic operation
            if (typeof(IComparable).IsAssignableFrom(expression.LeftArg.Expression.GetType()))
            {
                //left part is primitive type, build a parameter for the primitive
                if (expression.RightArg.Expression is FieldExpression field)
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.LeftArg.Expression, builder.FindMetadata(field)).Parameter.ParameterName);
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.LeftArg.Expression, expression.LeftArg.Expression.GetType()).ParameterName);
                }
            }
            else
            {
                //left part isn't a primitive type, append using builder
                builder.AppendPart(expression.LeftArg, context);
            }

            //append the operator
            builder.Appender.Write(ArithmeticOperatorMap[expression.ExpressionOperator]);

            //right part of arithmetic operation
            if (typeof(IComparable).IsAssignableFrom(expression.RightArg.Expression.GetType()))
            {
                //right part is primitive type, build a parameter for the primitive
                if (expression.LeftArg.Expression is FieldExpression field)
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.RightArg.Expression, builder.FindMetadata(field)).Parameter.ParameterName);
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.RightArg.Expression, expression.RightArg.Expression.GetType()).ParameterName);
                }
            }
            else
            {
                //right part isn't a primitive type, append using builder
                builder.AppendPart(expression.RightArg, context);
            }

            builder.Appender.Write(")");
        }
    }
}
