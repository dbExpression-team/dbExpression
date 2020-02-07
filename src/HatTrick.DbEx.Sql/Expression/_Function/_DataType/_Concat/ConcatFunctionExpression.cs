using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ConcatFunctionExpression : DataTypeFunctionExpression,
        IDbFunctionExpression,
        IAssemblyPart,
        ISupportedForExpression<SelectExpression>,
        ISupportedForFunctionExpression<CastFunctionExpression>,
        IEquatable<ConcatFunctionExpression>
    {
        #region constructors
        protected ConcatFunctionExpression()
        {
        }

        protected ConcatFunctionExpression(params (Type, object)[] expressions)
            : base((typeof(ConcatFunctionExpression), expressions.ToList()))
        {
        }
        #endregion

        #region to string
        public override string ToString() => $"CONCAT({string.Join(", ", (Expression.Item2 as IList<(Type,object)>)?.Select(e => e.Item2))})";
        #endregion

        #region equals
        public bool Equals(ConcatFunctionExpression obj)
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
            => obj is ConcatFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
