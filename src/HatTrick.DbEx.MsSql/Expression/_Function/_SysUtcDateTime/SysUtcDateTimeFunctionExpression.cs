using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class SysUtcDateTimeFunctionExpression : DataTypeFunctionExpression,
        IExpressionElement<DateTime>,
        DateTimeElement,
        IExpressionAliasProvider,
        IEquatable<SysUtcDateTimeFunctionExpression>
    {
        #region constructors
        public SysUtcDateTimeFunctionExpression() : base(null, typeof(DateTime))
        {

        }

        protected SysUtcDateTimeFunctionExpression(string alias) : base(null, typeof(DateTime), alias)
        {

        }
        #endregion

        #region methods
        #region as
        public DateTimeElement As(string alias)
            => new SysUtcDateTimeFunctionExpression(alias);
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
        #endregion
    }
}
