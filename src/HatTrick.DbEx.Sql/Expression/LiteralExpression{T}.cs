using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class LiteralExpression<TValue> : LiteralExpression
    {
        public FieldExpression FieldExpressionHint { get; }

        #region constructors
        public LiteralExpression(TValue value) : base(value)
        {

        }

        public LiteralExpression(TValue value, FieldExpression field) : base(value)
        {
            FieldExpressionHint = field;
        }
        #endregion
    }
}
