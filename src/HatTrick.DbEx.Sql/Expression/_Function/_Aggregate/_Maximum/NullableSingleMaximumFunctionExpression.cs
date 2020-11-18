using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleMaximumFunctionExpression :
        NullableMaximumFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleMaximumFunctionExpression>
    {
        #region constructors
        public NullableSingleMaximumFunctionExpression(NullSingleElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableSingleMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleMaximumFunctionExpression obj)
            => obj is NullableSingleMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
