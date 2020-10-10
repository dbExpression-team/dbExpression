using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InExpression<TValue> : InExpression
    {
        #region constructors
        public InExpression(IEnumerable<TValue> values) : base(values)
        {

        }
        #endregion
    }
}
