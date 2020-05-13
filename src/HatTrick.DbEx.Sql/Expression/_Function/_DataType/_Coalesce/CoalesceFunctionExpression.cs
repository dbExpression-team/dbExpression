using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CoalesceFunctionExpression : DataTypeFunctionExpression,
        IDbFunctionExpression,
        IEquatable<CoalesceFunctionExpression>
    {
        #region constructors
        protected CoalesceFunctionExpression(Type @type, params ExpressionContainer[] expressions) : base(new ExpressionContainer(expressions?.ToList() ?? throw new ArgumentNullException($"{nameof(expressions)} is required."), @type))
        {
        }
        #endregion

        #region to string
        public override string ToString() => $"COALESCE({string.Join(", ", (Expression.Object as IList<ExpressionContainer>)?.Select(e => e.Object))})";
        #endregion

        #region equals
        public bool Equals(CoalesceFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            var lst1 = Expression.Object as IList<ExpressionContainer>;
            var lst2 = obj.Expression.Object as IList<ExpressionContainer>;

            if (lst1.Count != lst2.Count) return false;

            foreach (var exp in lst1)
                if (!lst2.Any(e => e.Equals(exp))) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is CoalesceFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
