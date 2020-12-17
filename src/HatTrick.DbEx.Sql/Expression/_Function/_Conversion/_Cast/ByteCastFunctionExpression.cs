using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteCastFunctionExpression :
        CastFunctionExpression<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteCastFunctionExpression>
    {
        #region constructors
        public ByteCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public ByteElement As(string alias)
            => new ByteSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(ByteCastFunctionExpression obj)
            => obj is ByteCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
