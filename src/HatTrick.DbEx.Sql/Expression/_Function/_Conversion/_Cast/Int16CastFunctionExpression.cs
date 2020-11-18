using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16CastFunctionExpression :
        CastFunctionExpression<short>,
        Int16Element,
        AnyInt16Element,
        IEquatable<Int16CastFunctionExpression>
    {
        #region constructors
        public Int16CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType, typeof(short))
        {

        }

        protected Int16CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, typeof(short), size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public Int16Element As(string alias)
            => new Int16CastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
        #endregion

        #region equals
        public bool Equals(Int16CastFunctionExpression obj)
            => obj is Int16CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
