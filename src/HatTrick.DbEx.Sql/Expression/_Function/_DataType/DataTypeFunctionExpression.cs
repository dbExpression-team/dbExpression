using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DataTypeFunctionExpression : FunctionExpression
    {
        #region constructors
        protected DataTypeFunctionExpression()
        { 
        }

        public DataTypeFunctionExpression(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion
    }
}
