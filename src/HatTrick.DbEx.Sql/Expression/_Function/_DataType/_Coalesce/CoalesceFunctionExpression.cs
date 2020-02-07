using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CoalesceFunctionExpression : DataTypeFunctionExpression,
        IDbFunctionExpression,
        IAssemblyPart,
        ISupportedForExpression<SelectExpression>,
        ISupportedForFunctionExpression<CastFunctionExpression>,
        IEquatable<CoalesceFunctionExpression>
    {
        #region constructors
        protected CoalesceFunctionExpression()
        {
        }

        protected CoalesceFunctionExpression(params (Type, object)[] expressions)
            : base((typeof(CoalesceFunctionExpression), expressions.ToList()))
        {
        }
        #endregion

        #region to string
        public override string ToString() => $"COALESCE({string.Join(", ", (Expression.Item2 as IList<(Type,object)>)?.Select(e => e.Item2))})";
        #endregion

        #region equals
        public bool Equals(CoalesceFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            var lst1 = Expression.Item2 as IList<(Type, object)>;
            var lst2 = obj.Expression.Item2 as IList<(Type, object)>;

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
