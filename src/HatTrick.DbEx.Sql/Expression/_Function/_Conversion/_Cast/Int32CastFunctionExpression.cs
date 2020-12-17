using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32CastFunctionExpression :
        CastFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32CastFunctionExpression>
    {
        #region constructors
        public Int32CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
            => new Int32SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(Int32CastFunctionExpression obj)
            => obj is Int32CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
