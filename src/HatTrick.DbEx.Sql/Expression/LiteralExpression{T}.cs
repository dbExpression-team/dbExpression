using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class LiteralExpression<TValue> : LiteralExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        public LiteralExpression(TValue value) : base(value)
        {

        }

        public LiteralExpression(DBNull value) : base(value)
        {

        }
        #endregion
    }
}
