using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidMaximumFunctionExpression :
        NullableMaximumFunctionExpression<Guid,Guid?>,
        NullGuidElement,
        AnyGuidElement,
        IEquatable<NullableGuidMaximumFunctionExpression>
    {
        #region constructors
        public NullableGuidMaximumFunctionExpression(NullGuidElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableGuidMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullGuidElement As(string alias)
            => new NullableGuidMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableGuidMaximumFunctionExpression obj)
            => obj is NullableGuidMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
