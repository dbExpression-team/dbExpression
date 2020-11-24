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
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public Int64Element As(string alias)
        {
            Alias = alias;
            return this;
        }
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
