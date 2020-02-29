using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class AggregateFunctionExpression : FunctionExpression
    {
        #region constructors
        protected AggregateFunctionExpression()
        { 
        
        }

        protected AggregateFunctionExpression(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion
    }
}
