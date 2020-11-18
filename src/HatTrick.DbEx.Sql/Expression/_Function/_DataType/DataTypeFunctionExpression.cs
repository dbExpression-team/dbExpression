using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DataTypeFunctionExpression : FunctionExpression
    {
        #region constructors
        protected DataTypeFunctionExpression(IExpressionElement expression, Type declaredType) 
            : base(expression, declaredType)
        {

        }

        protected DataTypeFunctionExpression(IExpressionElement expression, Type declaredType, string alias)
            : base(expression, declaredType, alias)
        {

        }
        #endregion
    }
}
