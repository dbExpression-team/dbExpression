using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class LiteralExpression<TValue> : LiteralExpression
    {
        #region constructors
        public LiteralExpression(TValue value) : base(value)
        {

        }
        #endregion
    }
}
