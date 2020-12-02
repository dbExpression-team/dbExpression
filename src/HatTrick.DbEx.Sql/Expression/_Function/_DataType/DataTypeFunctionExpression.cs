using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DataTypeFunctionExpression : FunctionExpression,
        AnyGroupByClause
    {
        #region constructors
        protected DataTypeFunctionExpression(IExpressionElement expression, Type declaredType) 
            : base(expression, declaredType)
        {

        }
        #endregion

        #region implicit operators
        public static implicit operator GroupByExpression(DataTypeFunctionExpression a) => new GroupByExpression(a);
        #endregion
    }
}
