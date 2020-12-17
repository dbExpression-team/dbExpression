using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleCastFunctionExpression :
        NullableCastFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleCastFunctionExpression>
    {
        #region constructors
        public NullableSingleCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public NullableSingleElement As(string alias)
            => new NullableSingleSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleCastFunctionExpression obj)
            => obj is NullableSingleCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
