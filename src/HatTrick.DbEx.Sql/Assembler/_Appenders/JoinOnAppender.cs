using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinOnAppender :
        IAssemblyPartAppender<JoinOnExpressionSet>,
        IAssemblyPartAppender<JoinOnExpression>
    {
        private static IDictionary<FilterExpressionOperator, string> _filterOperatorMap;
        private static IDictionary<FilterExpressionOperator, string> FilterOperatorMap => _filterOperatorMap ?? (_filterOperatorMap = typeof(FilterExpressionOperator).GetValuesAndFilterOperators());
        
        public void AppendPart(JoinOnExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            throw new NotImplementedException("Should be handled by outside builder");
        }

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as JoinOnExpression, builder, context);

        public void AppendPart(JoinOnExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.AppendPart(expression.LeftPart, context);
            if (expression.ExpressionOperator == FilterExpressionOperator.In)
            {
                throw new InvalidOperationException("Join on clause does not support in");
            }

            builder.Appender.Write(FilterOperatorMap[expression.ExpressionOperator]);

            //TODO: JRod, is there any way to defer to  FieldAppender.AppendPart if this condition == true
            if (expression.RightPart.Item2 is FieldExpression field)
            {
                context.CurrentField = new AssemblerContext.CurrentFieldContext(field);

                var emit = context.EmitAlias;
                context.EmitAlias = false;
                if (expression.RightPart.Item2 is IDbExpressionAliasProvider alias && !string.IsNullOrWhiteSpace(alias.Alias))
                {
                    context.CurrentField.NameOverride = alias.Alias;
                }
                builder.AppendPart(expression.RightPart, context);
                context.CurrentField = null;
                context.EmitAlias = emit;
            }
            else if (typeof(IComparable).IsAssignableFrom(expression.RightPart.Item1))
            {
                builder.Appender.Write(builder.Parameters.Add(builder.FormatValueType(expression.RightPart), context.CurrentField.Field).Parameter.ParameterName);
            }
            else
            {
                builder.AppendPart(expression.RightPart, context);
            }
        }
    }
}
