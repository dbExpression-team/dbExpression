using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCastFunctionExpression : CastFunctionExpression
    {
        #region constructors
        protected NullableCastFunctionExpression()
        {
        }

        protected NullableCastFunctionExpression((Type, object) expression) : base(expression)
        {
        }
        #endregion    
    }
}
