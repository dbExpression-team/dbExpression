using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public class SkipBuilder<T, U> : ISkipBuilder<T, U>
        where U : IBuilder<T>
    {
        private DBExpressionSet Expression { get; set; }
        private U Caller { get; set; }

        internal SkipBuilder(DBExpressionSet expression, DBExpressionEntity joinOn, DBExpressionJoinType joinType, U caller)
        {
            Expression = expression;
            Caller = caller;
        }

        U ISkipBuilder<T, U>.Skip(int skip)
        {
            Expression.SkipValue = skip;
            return Caller;
        }
    }
}
