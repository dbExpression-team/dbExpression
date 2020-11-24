using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleCastFunctionExpression :
        CastFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleCastFunctionExpression>
    {
        #region constructors
        public SingleCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleCastFunctionExpression obj)
            => obj is SingleCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
