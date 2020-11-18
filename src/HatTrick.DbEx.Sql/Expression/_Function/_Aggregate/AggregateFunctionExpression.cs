using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class AggregateFunctionExpression : FunctionExpression
    {
        #region constructors
        protected AggregateFunctionExpression(IExpressionElement expression, Type declaredType) : base(expression, declaredType)
        {

        }

        protected AggregateFunctionExpression(IExpressionElement expression, Type declaredType, string alias) : base(expression, declaredType, alias)
        {

        }
        #endregion
    }
}
