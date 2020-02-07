using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Builder
{
    public class CastFunctionExpressionBuilder<TValue> : CastFunctionExpressionBuilder
    {
        #region constructors
        public CastFunctionExpressionBuilder((Type, object) expression) : base(expression)
        {
        }
        #endregion
    }
}
