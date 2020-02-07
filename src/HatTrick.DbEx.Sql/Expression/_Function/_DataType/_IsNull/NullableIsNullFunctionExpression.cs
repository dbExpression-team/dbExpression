using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableIsNullFunctionExpression : IsNullFunctionExpression
    {
        #region constructors
        protected NullableIsNullFunctionExpression()
        {
        }

        protected NullableIsNullFunctionExpression((Type, object) expression, (Type, object) value) : base(expression, value)
        {
        }
        #endregion    
    }
}
