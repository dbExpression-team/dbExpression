using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ConversionFunctionExpression : FunctionExpression,
        AnyGroupByClause
    {
        #region constructors
        protected ConversionFunctionExpression(IExpressionElement expression, Type convertToType) 
            : base(expression, convertToType)
        {

        }
        #endregion
    }
}
