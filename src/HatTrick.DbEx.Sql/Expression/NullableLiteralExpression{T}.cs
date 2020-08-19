using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableLiteralExpression<TValue> : LiteralExpression
    {
        public NullableLiteralExpression() : base(DBNull.Value)
        {

        }

        public NullableLiteralExpression(TValue value) : base(value)
        {

        }
    }
}
