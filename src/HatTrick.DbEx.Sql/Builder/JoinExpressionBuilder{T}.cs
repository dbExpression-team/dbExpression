using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class JoinExpressionBuilder<T> : IJoinExpressionBuilder<T>
        where T : IExpressionBuilder
    {
        private QueryExpression Expression { get; set; }
        private IExpressionElement JoinOn { get; set; }
        private JoinOperationExpressionOperator JoinType { get; set; }
        private T Caller { get; set; }
        protected string Alias { get; set; }

        public JoinExpressionBuilder(QueryExpression expression, EntityExpression joinOn, JoinOperationExpressionOperator joinType, T caller)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
            JoinOn = joinOn ?? throw new ArgumentNullException($"{nameof(joinOn)} is required.");
            JoinType = joinType;
            Caller = caller is object ? caller : throw new ArgumentNullException($"{nameof(caller)} is required.");
        }

        public JoinExpressionBuilder(QueryExpression expression, QueryExpression subquery, JoinOperationExpressionOperator joinType, T caller)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
            JoinOn = subquery ?? throw new ArgumentNullException($"{nameof(subquery)} is required.");
            JoinType = joinType;
            Caller = caller is object ? caller : throw new ArgumentNullException($"{nameof(caller)} is required.");
        }

        T IJoinExpressionBuilder<T>.On(JoinOnExpressionSet joinOn)
        {
            Expression.Joins = Expression.Joins is null ? 
                new JoinExpressionSet(new JoinExpression(JoinOn, JoinType, joinOn, Alias)) 
                : 
                new JoinExpressionSet(Expression.Joins.Expressions.Concat(new JoinExpression[1] { new JoinExpression(JoinOn, JoinType, joinOn, Alias) }));

            return Caller;
        }
    }
}
