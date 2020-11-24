using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class SysDateTimeOffsetFunctionExpression : DataTypeFunctionExpression,
        IExpressionElement<DateTime>,
        DateTimeElement,
        IExpressionAliasProvider,
        IEquatable<SysDateTimeOffsetFunctionExpression>
    {
        #region constructors
        public SysDateTimeOffsetFunctionExpression() : base(null, typeof(DateTimeOffset))
        {

        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "GetUtcDate()";
        #endregion

        #region equals
        public bool Equals(SysDateTimeOffsetFunctionExpression obj)
            => base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SysDateTimeOffsetFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
