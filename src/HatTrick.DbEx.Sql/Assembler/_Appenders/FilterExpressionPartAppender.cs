using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FilterExpressionPartAppender : PartAppender<FilterExpression>, 
        IAssemblyPartAppender<FilterExpression<bool>>,
        IAssemblyPartAppender<FilterExpression<bool?>>
    {
        #region internals
        private static IDictionary<FilterExpressionOperator, string> _filterOperatorMap;
        private static IDictionary<FilterExpressionOperator, string> FilterOperatorMap => _filterOperatorMap ?? (_filterOperatorMap = typeof(FilterExpressionOperator).GetValuesAndFilterOperators(x => $" {x} "));
        #endregion

        #region methods
        public override void AppendPart(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendFilterExpressionUsingExpressionAppendStyles(expression, builder, context, EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);

        private void AppendFilterExpressionUsingExpressionAppendStyles(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context, EntityExpressionAppendStyle entityAppendStyle, FieldExpressionAppendStyle fieldAppendStyle)
        {
            context.PushAppendStyles(entityAppendStyle, fieldAppendStyle);
            try
            {
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
            if (expression.LeftArg.Expression is LiteralExpression left && left.Expression is DBNull || expression.RightArg.Expression is LiteralExpression right && right.Expression is DBNull)
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
            if (expression.LeftArg.Expression is LiteralExpression left && left.Expression is DBNull)
            {
                AppendFilterExpressionWithDBNull(expression, expression.RightArg, builder, context);
            }
            else
            {
                AppendFilterExpressionWithDBNull(expression, expression.LeftArg, builder, context);
            }
        }

        private void AppendFilterExpressionWithDBNull(FilterExpression expression, ExpressionMediator nonDBNull, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendPart(nonDBNull, context);
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
            builder.AppendPart(expression.LeftArg, context);

            builder.Appender.Write(FilterOperatorMap[expression.ExpressionOperator]);
            context.PushField(expression.LeftArg.Expression as FieldExpression);
            try
            {
                builder.AppendPart(expression.RightArg, context);
            }
            finally
            {
                context.PopField();
            }

            if (expression.Negate)
            {
                builder.Appender.Write(')');
            }
        }

        public void AppendPart(FilterExpression<bool> expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as FilterExpression, builder, context);

        public void AppendPart(FilterExpression<bool?> expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as FilterExpression, builder, context);
        #endregion
    }
}
