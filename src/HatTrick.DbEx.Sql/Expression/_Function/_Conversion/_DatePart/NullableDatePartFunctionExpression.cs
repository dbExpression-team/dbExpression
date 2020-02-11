using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDatePartFunctionExpression : DatePartFunctionExpression,
        ISupportedForSelectFieldExpression<int?>, 
        ISupportedForFunctionExpression<CountFunctionExpression, int>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, int?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>,
        ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<int?>>
    {
        #region constructors
        protected NullableDatePartFunctionExpression()
        {
        }

        protected NullableDatePartFunctionExpression((Type, object) datePart, (Type, object) expression)
            : base(datePart, expression)
        {
        }
        #endregion
    }
}
