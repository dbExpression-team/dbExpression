using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<DateTime,DateTime?>,
        NullDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeCoalesceFunctionExpression>
    {
        #region constructors
        public NullableDateTimeCoalesceFunctionExpression(IList<AnyDateTimeElement> expressions) 
            : base(expressions)
        {

        }

        public NullableDateTimeCoalesceFunctionExpression(IList<AnyDateTimeElement> expressions, DateTimeElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableDateTimeCoalesceFunctionExpression(IList<AnyDateTimeElement> expressions, NullDateTimeElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableDateTimeCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullDateTimeElement As(string alias)
            => new NullableDateTimeCoalesceFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeCoalesceFunctionExpression obj)
            => obj is NullableDateTimeCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
