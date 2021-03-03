using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql
{
    internal static class ExpressionElementExtensions
    {
        internal static FieldExpression AsFieldExpression(this IExpressionElement expression)
        {
            if (expression is FieldExpression field)
                return field;

            if (expression is SelectExpression select)
                return AsFieldExpression(select.Expression);

            if (expression is ExpressionMediator mediator)
                return AsFieldExpression(mediator.Expression);

            return null;
        }

        internal static SelectExpression ToSelectExpression(this IExpressionElement expression, ISqlDatabaseMetadataProvider metadata)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (expression is SelectExpression select)
                return select;

            var field = expression.AsFieldExpression();

            if (field is null)
                return new SelectExpression(expression);

            if (metadata is null)
                throw new ArgumentNullException(nameof(metadata));

            var dbName = metadata.FindFieldMetadata((field as ISqlMetadataIdentifierProvider).Identifier)?.Name ?? throw new DbExpressionException($"Cannot resolve metadata for {expression}.");
            var codeName = (field as IExpressionNameProvider).Name;

            return dbName == codeName ? new SelectExpression(expression) : new SelectExpression(expression, codeName);
        }
    }
}
