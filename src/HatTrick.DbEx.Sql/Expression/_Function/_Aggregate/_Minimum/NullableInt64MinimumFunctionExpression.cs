using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64MinimumFunctionExpression :
        NullableMinimumFunctionExpression<long,long?>,
        NullInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64MinimumFunctionExpression>
    {
        #region constructors
        public NullableInt64MinimumFunctionExpression(NullInt64Element expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableInt64MinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullInt64Element As(string alias)
            => new NullableInt64MinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt64MinimumFunctionExpression obj)
            => obj is NullableInt64MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
