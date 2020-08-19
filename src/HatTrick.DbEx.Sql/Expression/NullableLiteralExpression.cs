using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableLiteralExpression : LiteralExpression
    {
        public NullableLiteralExpression() : base(DBNull.Value)
        {

        }
    }
}
