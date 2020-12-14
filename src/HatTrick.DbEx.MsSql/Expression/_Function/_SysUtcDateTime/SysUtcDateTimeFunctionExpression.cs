using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class SysUtcDateTimeFunctionExpression : DataTypeFunctionExpression,
        IExpressionElement<DateTime>,
        AnyDateTimeElement,
        DateTimeElement,
        IExpressionAliasProvider,
        IEquatable<SysUtcDateTimeFunctionExpression>
    {
        #region constructors
        public SysUtcDateTimeFunctionExpression() : base(null, typeof(DateTime))
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
        public bool Equals(SysUtcDateTimeFunctionExpression obj)
            => base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SysUtcDateTimeFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
