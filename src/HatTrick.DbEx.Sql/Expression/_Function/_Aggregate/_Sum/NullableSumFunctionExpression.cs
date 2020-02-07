using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableSumFunctionExpression : SumFunctionExpression
    {
        #region constructors
        protected NullableSumFunctionExpression()
        {
        }

        protected NullableSumFunctionExpression((Type, object) expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
