using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<DateTimeOffset,DateTimeOffset?>,
        NullDateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<NullableDateTimeOffsetCoalesceFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetCoalesceFunctionExpression(IList<AnyDateTimeOffsetElement> expressions) 
            : base(expressions)
        {

        }

        public NullableDateTimeOffsetCoalesceFunctionExpression(IList<AnyDateTimeOffsetElement> expressions, DateTimeOffsetElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableDateTimeOffsetCoalesceFunctionExpression(IList<AnyDateTimeOffsetElement> expressions, NullDateTimeOffsetElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableDateTimeOffsetCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullDateTimeOffsetElement As(string alias)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetCoalesceFunctionExpression obj)
            => obj is NullableDateTimeOffsetCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
