using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class CurrentTimestampFunctionExpression : DataTypeFunctionExpression,
        IDbDateFunctionExpression,
        IEquatable<CurrentTimestampFunctionExpression>
    {
        #region as
        public new CurrentTimestampFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "CURRENT_TIMESTAMP";
        #endregion

        #region equals
        public bool Equals(CurrentTimestampFunctionExpression obj)
            => base.Equals(obj);

        public override bool Equals(object obj)
         => obj is CurrentTimestampFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
