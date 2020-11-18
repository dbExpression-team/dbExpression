using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ArithmeticExpressionAppender : ExpressionElementAppender<ArithmeticExpression>
    {
        private static IDictionary<ArithmeticExpressionOperator, string> _arithmeticOperatorMap;
        private static IDictionary<ArithmeticExpressionOperator, string> ArithmeticOperatorMap => _arithmeticOperatorMap ?? (_arithmeticOperatorMap = typeof(ArithmeticExpressionOperator).GetValuesAndArithmeticOperators(x => string.IsNullOrWhiteSpace(x) ? " " : $" {x} "));

        public override void AppendElement(ArithmeticExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("(");

            //left part of arithmetic operation
            if (typeof(IComparable).IsAssignableFrom(expression.LeftArg.GetType()))
            {
                //left part is primitive type, build a parameter for the primitive
                if (expression.RightArg.AsFieldExpression() is FieldExpression field)
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.LeftArg, builder.FindMetadata(field)).Parameter.ParameterName);
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.LeftArg, expression.LeftArg.GetType()).ParameterName);
                }
            }
            else
            {
                //left part isn't a primitive type, append using builder
                builder.AppendElement(expression.LeftArg, context);
            }

            //append the operator
            builder.Appender.Write(ArithmeticOperatorMap[expression.ExpressionOperator]);

            //right part of arithmetic operation
            if (typeof(IComparable).IsAssignableFrom(expression.RightArg.GetType()))
            {
                //right part is primitive type, build a parameter for the primitive
                if (expression.LeftArg.AsFieldExpression() is FieldExpression field)
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.RightArg, builder.FindMetadata(field)).Parameter.ParameterName);
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.RightArg, expression.RightArg.GetType()).ParameterName);
                }
            }
            else
            {
                //right part isn't a primitive type, append using builder
                builder.AppendElement(expression.RightArg, context);
            }

            builder.Appender.Write(")");
        }
    }
}
