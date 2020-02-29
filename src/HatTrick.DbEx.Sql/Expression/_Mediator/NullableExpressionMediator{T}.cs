using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableExpressionMediator<TValue> : ExpressionMediator<TValue>
    {
        #region constructors
        protected NullableExpressionMediator()
        { }

        public NullableExpressionMediator(ExpressionContainer expression)
            : base(expression)
        {
        }
        #endregion
    }
}
