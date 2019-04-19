using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class LiteralExpression
    {
        public (Type, object) Expression { get; private set; }

        protected LiteralExpression(object value)
        {
            Expression = (value.GetType(), value);
        }
    }
}
