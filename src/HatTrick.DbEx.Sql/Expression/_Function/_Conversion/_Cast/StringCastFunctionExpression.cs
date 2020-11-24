using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringCastFunctionExpression :
        CastFunctionExpression<string>,
        StringElement,
        AnyStringElement,
        IEquatable<StringCastFunctionExpression>
    {
        #region constructors
        public StringCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int size)
            : base(expression, convertToDbType, size)
        {

        }
        #endregion

        #region as
        public StringElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(StringCastFunctionExpression obj)
            => obj is StringCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
