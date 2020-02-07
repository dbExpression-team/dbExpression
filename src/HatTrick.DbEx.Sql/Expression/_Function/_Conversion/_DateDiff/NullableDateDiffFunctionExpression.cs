using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateDiffFunctionExpression : DateDiffFunctionExpression,
        ISupportedForFunctionExpression<CountFunctionExpression, int>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, int?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>,
        ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, int?>,
        ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, int?>
    {
        #region constructors
        protected NullableDateDiffFunctionExpression()
        {
        }

        protected NullableDateDiffFunctionExpression((Type, object) datePart, (Type, object) startDate, (Type, object) endDate)
            : base(datePart, startDate, endDate)
        {
        }
        #endregion
    }
}
