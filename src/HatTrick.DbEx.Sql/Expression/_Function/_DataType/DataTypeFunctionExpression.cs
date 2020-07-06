using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DataTypeFunctionExpression : FunctionExpression
    {
        #region constructors
        protected DataTypeFunctionExpression()
        { 
        }

        public DataTypeFunctionExpression(ExpressionMediator expression) : base(expression)
        {
        }
        #endregion
    }
}
