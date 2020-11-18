using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64MaximumFunctionExpression :
        NullableMaximumFunctionExpression<long,long?>,
        NullInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64MaximumFunctionExpression>
    {
        #region constructors
        public NullableInt64MaximumFunctionExpression(NullInt64Element expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableInt64MaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullInt64Element As(string alias)
            => new NullableInt64MaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt64MaximumFunctionExpression obj)
            => obj is NullableInt64MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
