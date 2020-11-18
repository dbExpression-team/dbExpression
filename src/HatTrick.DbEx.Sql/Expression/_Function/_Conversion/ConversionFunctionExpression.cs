using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ConversionFunctionExpression : FunctionExpression
    {
        #region constructors
        protected ConversionFunctionExpression(IExpressionElement expression, Type convertToType, string alias) 
            : base(expression, convertToType, alias)
        {

        }
        #endregion
    }
}
