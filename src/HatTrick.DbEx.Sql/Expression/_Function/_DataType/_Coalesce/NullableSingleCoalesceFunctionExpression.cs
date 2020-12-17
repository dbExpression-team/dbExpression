using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleCoalesceFunctionExpression>
    {
        #region constructors
        public NullableSingleCoalesceFunctionExpression(IList<AnySingleElement> expressions) 
            : base(expressions)
        {

        }

        public NullableSingleCoalesceFunctionExpression(IList<AnySingleElement> expressions, SingleElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        public NullableSingleCoalesceFunctionExpression(IList<AnySingleElement> expressions, NullableSingleElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }
        #endregion

        #region as
        public NullableSingleElement As(string alias)
            => new NullableSingleSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleCoalesceFunctionExpression obj)
            => obj is NullableSingleCoalesceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleCoalesceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
