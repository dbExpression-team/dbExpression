using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableStandardDeviationFunctionExpression : StandardDeviationFunctionExpression
    {
        #region constructors
        protected NullableStandardDeviationFunctionExpression()
        {
        }

        protected NullableStandardDeviationFunctionExpression((Type, object) expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
