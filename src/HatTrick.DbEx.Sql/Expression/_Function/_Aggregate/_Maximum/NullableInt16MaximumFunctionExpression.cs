using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16MaximumFunctionExpression :
        NullableMaximumFunctionExpression<short,short?>,
        NullInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16MaximumFunctionExpression>
    {
        #region constructors
        public NullableInt16MaximumFunctionExpression(NullInt16Element expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableInt16MaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullInt16Element As(string alias)
            => new NullableInt16MaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt16MaximumFunctionExpression obj)
            => obj is NullableInt16MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
