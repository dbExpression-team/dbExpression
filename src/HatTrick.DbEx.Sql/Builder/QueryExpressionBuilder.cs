using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class QueryExpressionBuilder :
        ITerminationExpressionBuilder,
        IQueryExpressionProvider
    {
        #region interface
        public RuntimeSqlDatabaseConfiguration Configuration { get; private set; }
        public virtual QueryExpression Expression { get; private set; }
        QueryExpression IQueryExpressionProvider.Expression => Expression;
        #endregion

        #region constructors
        protected QueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, QueryExpression expression)
        {
            Configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.");
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
        }
        #endregion

        #region methods
        protected U Where<U>(FilterExpressionSet expression) where U : class, IExpressionBuilder
        {
            if (expression is null)
                return this as U;

            if (Expression.Where?.LeftArg is null)
                Expression.Where = expression;
            else
                Expression.Where &= expression;
            return this as U;
        }

        protected U Where<T, U>(FilterExpressionSet expression) where U : class, IExpressionBuilder<T>
        {
            if (expression is null)
                return this as U;

            if (Expression.Where?.LeftArg is null)
                Expression.Where = expression;
            else
                Expression.Where &= expression;
            return this as U;
        }

        protected IJoinExpressionBuilder<T> Join<T>(EntityExpression joinEntity, JoinOperationExpressionOperator joinType)
            where T : class, IExpressionBuilder
        {
            return new JoinExpressionBuilder<T>(Expression, joinEntity, joinType, this as T);
        }

        protected IJoinExpressionBuilder<T, TBuilder> Join<T, TBuilder>(EntityExpression joinEntity, JoinOperationExpressionOperator joinType)
            where TBuilder : class, IExpressionBuilder<T>
        {
            return new JoinExpressionBuilder<T, TBuilder>(Expression, joinEntity, joinType, this as TBuilder);
        }

        protected IAliasRequiredJoinExpressionBuilder<T, TBuilder> Join<T, TBuilder>(ISubqueryTerminationExpressionBuilder subquery, JoinOperationExpressionOperator joinType)
            where TBuilder : class, IExpressionBuilder<T>
        {
            return new JoinExpressionBuilder<T, TBuilder>(Expression, (subquery as IQueryExpressionProvider).Expression, joinType, this as TBuilder);
        }
        #endregion
    }
}
