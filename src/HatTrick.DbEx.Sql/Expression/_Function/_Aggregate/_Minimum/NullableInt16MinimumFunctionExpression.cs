using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16MinimumFunctionExpression :
        NullableMinimumFunctionExpression<short,short?>,
        NullInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16MinimumFunctionExpression>
    {
        #region constructors
        public NullableInt16MinimumFunctionExpression(NullInt16Element expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableInt16MinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullInt16Element As(string alias)
            => new NullableInt16MinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt16MinimumFunctionExpression obj)
            => obj is NullableInt16MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
