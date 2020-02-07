using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ConversionFunctionExpression : FunctionExpression
    {
        #region constructors
        protected ConversionFunctionExpression()
        {
        }

        public ConversionFunctionExpression((Type, object) expression) : base(expression)
        {
        }
        #endregion
    }
}
