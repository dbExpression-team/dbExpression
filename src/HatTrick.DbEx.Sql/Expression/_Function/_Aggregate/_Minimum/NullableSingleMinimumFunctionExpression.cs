using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleMinimumFunctionExpression :
        NullableMinimumFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleMinimumFunctionExpression>
    {
        #region constructors
        public NullableSingleMinimumFunctionExpression(NullSingleElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableSingleMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleMinimumFunctionExpression obj)
            => obj is NullableSingleMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
