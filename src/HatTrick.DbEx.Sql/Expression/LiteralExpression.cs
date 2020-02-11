using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class LiteralExpression
    {
        public (Type, object) Expression { get; private set; }

        protected LiteralExpression((Type, object) expression)
        {
            Expression = expression;
        }
    }
}
