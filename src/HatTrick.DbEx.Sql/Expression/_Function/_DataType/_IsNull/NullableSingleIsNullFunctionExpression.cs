using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleIsNullFunctionExpression :
        NullableIsNullFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleIsNullFunctionExpression>
    {
        #region constructors
        public NullableSingleIsNullFunctionExpression(AnySingleElement expression, NullSingleElement value)
            : base(expression, value)
        {

        }

        protected NullableSingleIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleIsNullFunctionExpression(base.Expression, base.Value, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleIsNullFunctionExpression obj)
            => obj is NullableSingleIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
