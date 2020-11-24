using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DateAddFunctionExpression<TValue> : DateAddFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected DateAddFunctionExpression(DatePartsExpression datePart, Int32Element value, IExpressionElement expression) 
            : base(datePart, value, expression, typeof(TValue))
        {

        }
        #endregion
    }
}
