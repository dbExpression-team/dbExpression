using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class GetUtcDateFunctionExpression : DataTypeFunctionExpression,
        IDateFunctionExpression,
        IExpressionAliasProvider,
        IEquatable<GetUtcDateFunctionExpression>
    {
        #region as
        public new GetUtcDateFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "GetUtcDate()";
        #endregion

        #region equals
        public bool Equals(GetUtcDateFunctionExpression obj)
            => base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GetUtcDateFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}