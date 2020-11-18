using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleCoalesceFunctionExpression :
        NullableCoalesceFunctionExpression<float,float?>,
        NullSingleElement,
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

        public NullableSingleCoalesceFunctionExpression(IList<AnySingleElement> expressions, NullSingleElement termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }))
        {

        }

        protected NullableSingleCoalesceFunctionExpression(IList<IExpressionElement> expressions, string alias) 
            : base(expressions, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleCoalesceFunctionExpression(base.Expression, alias);
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
