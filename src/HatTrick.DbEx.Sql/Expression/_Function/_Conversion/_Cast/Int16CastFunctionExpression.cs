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
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public Int16Element As(string alias)
        {
            Alias = alias;
            return this;
        }
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
