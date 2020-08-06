using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class GetDateFunctionExpression : DataTypeFunctionExpression,
        IDateFunctionExpression,
        IExpressionAliasProvider,
        IEquatable<GetDateFunctionExpression>
    {
        #region as
        public new GetDateFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "GETDATE()";
        #endregion

        #region equals
        public bool Equals(GetDateFunctionExpression obj)
            => base.Equals(obj); 

        public override bool Equals(object obj)
            => obj is GetDateFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
