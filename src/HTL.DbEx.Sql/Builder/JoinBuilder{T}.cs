using HTL.DbEx.Sql.Builder.Syntax;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder
{
    public class JoinBuilder<T> : IJoinBuilder<T>
        where T : IBuilder
    {
        private DBExpressionSet Expression { get; set; }
        private DBExpressionEntity JoinOn { get; set; }
        private DBExpressionJoinType JoinType { get; set; }
        private T Caller { get; set; }

        internal JoinBuilder(DBExpressionSet expression, DBExpressionEntity joinOn, DBExpressionJoinType joinType, T caller)
        {
            Expression = expression;
            JoinOn = joinOn;
            JoinType = joinType;
            Caller = caller;
        }

        T IJoinBuilder<T>.On(DBJoinOnExpression expression)
        {
            if (Expression.Joins == null)
                Expression.Joins = new DBJoinExpressionSet(new DBJoinExpression(JoinOn, JoinType, expression));
            else
                Expression.Joins.Expressions.Add(new DBJoinExpression(JoinOn, JoinType, expression));
            return Caller;
        }
    }
}
