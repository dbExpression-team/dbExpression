using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
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

        T IJoinBuilder<T>.On(DBFilterExpression expression)
        {
            Expression &= JoinOn.Join(JoinType, expression);
            return Caller;
        }
    }

    public class JoinBuilder<T, U> : JoinBuilder<U>, IJoinBuilder<T, U>
        where U : IBuilder<T>
    {

        internal JoinBuilder(DBExpressionSet expression, DBExpressionEntity joinOn, DBExpressionJoinType joinType, U caller)
            : base(expression, joinOn, joinType, caller)
        {
        }

    }
}
