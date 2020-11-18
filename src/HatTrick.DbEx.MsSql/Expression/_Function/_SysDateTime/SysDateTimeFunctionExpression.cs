using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class SysDateTimeFunctionExpression : DataTypeFunctionExpression,
        IExpressionElement<DateTime>,
        DateTimeElement,
        IExpressionAliasProvider,
        IEquatable<SysDateTimeFunctionExpression>
    {
        #region constructors
        public SysDateTimeFunctionExpression() : base(null, typeof(DateTime))
        {

        }

        protected SysDateTimeFunctionExpression(string alias) : base(null, typeof(DateTime), alias)
        {

        }
        #endregion

        #region methods
        #region as
        public DateTimeElement As(string alias)
            => new SysDateTimeFunctionExpression(alias);
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
        #endregion
    }
}
