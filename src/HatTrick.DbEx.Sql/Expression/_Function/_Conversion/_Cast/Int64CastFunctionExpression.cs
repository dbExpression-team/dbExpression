using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64CastFunctionExpression :
        CastFunctionExpression<long>,
        Int64Element,
        AnyInt64Element,
        IEquatable<Int64CastFunctionExpression>
    {
        #region constructors
        public Int64CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType, typeof(long))
        {

        }

        protected Int64CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, typeof(long), size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public Int64Element As(string alias)
            => new Int64CastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
        #endregion

        #region equals
        public bool Equals(Int64CastFunctionExpression obj)
            => obj is Int64CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
