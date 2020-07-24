using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public class JoinExpressionBuilder<T, U> : JoinExpressionBuilder<U>, 
        IJoinExpressionBuilder<T, U>,
        IAliasRequiredJoinExpressionBuilder<T, U>
        where U : IExpressionBuilder<T>
    {

        internal JoinExpressionBuilder(QueryExpression expression, EntityExpression joinOn, JoinOperationExpressionOperator joinType, U caller)
            : base(expression, joinOn, joinType, caller)
        {
        }

        internal JoinExpressionBuilder(QueryExpression expression, QueryExpression joinOn, JoinOperationExpressionOperator joinType, U caller)
            : base(expression, joinOn, joinType, caller)
        {
        }

        IJoinExpressionBuilder<T, U> IJoinExpressionBuilder<T, U>.As(string alias)
        {
            Alias = alias;
            return this;
        }

        IJoinExpressionBuilder<T, U> IAliasRequiredJoinExpressionBuilder<T, U>.As(string alias)
        {
            Alias = alias;
            return this;
        }
    }
}
