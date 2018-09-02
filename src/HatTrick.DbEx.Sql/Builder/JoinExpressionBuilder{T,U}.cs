using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public class JoinExpressionBuilder<T, U> : JoinExpressionBuilder<U>, IJoinExpressionBuilder<T, U>
        where U : IExpressionBuilder<T>
    {

        internal JoinExpressionBuilder(ExpressionSet expression, EntityExpression joinOn, JoinOperationExpressionOperator joinType, U caller)
            : base(expression, joinOn, joinType, caller)
        {
        }

    }
}
