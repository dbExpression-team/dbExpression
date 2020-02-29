using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FilterExpressionPartAppender : PartAppender<FilterExpression>
    {
        #region internals
        private static IDictionary<FilterExpressionOperator, string> _filterOperatorMap;
        private static IDictionary<FilterExpressionOperator, string> FilterOperatorMap => _filterOperatorMap ?? (_filterOperatorMap = typeof(FilterExpressionOperator).GetValuesAndFilterOperators());
        #endregion

        #region methods
        public override void AppendPart(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendFilterExpressionUsingExpressionAppendStyles(expression, builder, context, EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);

        private void AppendFilterExpressionUsingExpressionAppendStyles(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context, EntityExpressionAppendStyle entityAppendStyle, FieldExpressionAppendStyle fieldEAppendStyle)
        {
            try
            {
                context.PushAppendStyles(entityAppendStyle, fieldEAppendStyle);
                AppendFilterExpressionThatMayContainDBNull(expression, builder, context);
            }
            finally
            {
                context.PopAppendStyles();
            }
        }

        private void AppendFilterExpressionThatMayContainDBNull(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            //if either side of the filter expression is DBNull.Value, construct the side with an expression and append appropriate "IS NULL"
            if (expression.Expression.LeftPart.Type == typeof(DBNull) || expression.Expression.RightPart.Type == typeof(DBNull))
            {
                AppendFilterExpressionWithLeftOrRightEqualToDBNull(expression, builder, context);
            }
            else
            {
                //neither side of filter expression is DBNull.Value
                AppendFilterExpressionWithoutDBNull(expression, builder, context);
            }
        }

        private void AppendFilterExpressionWithLeftOrRightEqualToDBNull(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Expression.LeftPart.Type == typeof(DBNull))
            {
                AppendFilterExpressionWithDBNull(expression, expression.Expression.RightPart, builder, context);
            }
            else
            {
                AppendFilterExpressionWithDBNull(expression, expression.Expression.LeftPart, builder, context);
            }
        }

        private void AppendFilterExpressionWithDBNull(FilterExpression expression, ExpressionContainer nonDBNullContainer, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendPart(nonDBNullContainer, context);
            switch (expression.ExpressionOperator)
            {
                case FilterExpressionOperator.Equal:
                    builder.Appender.Write(expression.Negate ? " IS NOT NULL" : " IS NULL");
                    break;
                case FilterExpressionOperator.NotEqual:
                    builder.Appender.Write(expression.Negate ? " IS NULL" : " IS NOT NULL");
                    break;
                default:
                    throw new ArgumentException($"Operator {expression.ExpressionOperator} invalid with null arguments");
            }
        }

        private void AppendFilterExpressionWithoutDBNull(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Negate)
            {
                builder.Appender.Write("NOT (");
            }
            builder.AppendPart(expression.Expression.LeftPart, context);
            builder.Appender.Write(FilterOperatorMap[expression.ExpressionOperator]);
            if (expression.ExpressionOperator == FilterExpressionOperator.In && expression.Expression.RightPart.Object is Array arr)
            {
                builder.Appender.Write("(");
                for (var i = 0; i < arr.Length; i++)
                {
                    var value = arr.GetValue(i);
                    builder.AppendPart(new ExpressionContainer(value), context);
                    if (i != arr.Length - 1)
                        builder.Appender.Write(", ");
                }
                builder.Appender.Write(")");
            }
            else
            {
                context.Field = expression.Expression.LeftPart.Object as FieldExpression;
                builder.AppendPart(expression.Expression.RightPart, context);
                context.Field = null;
            }
            if (expression.Negate)
            {
                builder.Appender.Write(")");
            }
        }
        #endregion
    }
}
