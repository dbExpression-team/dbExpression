using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class SysDateTimeFunctionExpression : DataTypeFunctionExpression,
        IDbDateFunctionExpression,
        IDbExpressionAliasProvider,
        IEquatable<SysDateTimeFunctionExpression>
    {
        #region as
        public new SysDateTimeFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "SysDateTime()";
        #endregion

        #region equals
        public bool Equals(SysDateTimeFunctionExpression obj)
            => base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SysDateTimeFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
