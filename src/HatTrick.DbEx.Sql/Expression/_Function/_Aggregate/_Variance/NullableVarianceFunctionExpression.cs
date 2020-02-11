using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableVarianceFunctionExpression : VarianceFunctionExpression
    {
        #region constructors
        protected NullableVarianceFunctionExpression()
        {
        }

        protected NullableVarianceFunctionExpression((Type, object) expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
