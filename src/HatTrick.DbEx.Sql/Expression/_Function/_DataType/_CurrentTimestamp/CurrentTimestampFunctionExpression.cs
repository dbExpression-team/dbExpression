using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class CurrentTimestampFunctionExpression : DataTypeFunctionExpression,
        IExpressionElement<DateTime>,
        DateTimeElement,
        AnyDateTimeElement,
        IEquatable<CurrentTimestampFunctionExpression>
    {
        #region constructors
        public CurrentTimestampFunctionExpression() 
            : base(null, typeof(DateTime))
        {

        }

        protected CurrentTimestampFunctionExpression(string alias) : base(null, typeof(DateTime), alias)
        {

        }
        #endregion

        #region methods
        #region as
        public DateTimeElement As(string alias)
            => new CurrentTimestampFunctionExpression(alias);
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
        #endregion
    }
}
