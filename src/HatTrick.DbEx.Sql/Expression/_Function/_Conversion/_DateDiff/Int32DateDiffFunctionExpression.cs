using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32DateDiffFunctionExpression :
        DateDiffFunctionExpression<int>,
        IEquatable<Int32DateDiffFunctionExpression>
    {
        #region constructors
        public Int32DateDiffFunctionExpression(DatePartsExpression datePart, ExpressionMediator<DateTime> startDate, ExpressionMediator<DateTime> endDate) : base(datePart, startDate, endDate)
        {
        }

        public Int32DateDiffFunctionExpression(DatePartsExpression datePart, ExpressionMediator<DateTime> startDate, ExpressionMediator<DateTimeOffset> endDate) : base(datePart, startDate, endDate)
        {
        }

        public Int32DateDiffFunctionExpression(DatePartsExpression datePart, ExpressionMediator<DateTimeOffset> startDate, ExpressionMediator<DateTime> endDate) : base(datePart, startDate, endDate)
        {
        }

        public Int32DateDiffFunctionExpression(DatePartsExpression datePart, ExpressionMediator<DateTimeOffset> startDate, ExpressionMediator<DateTimeOffset> endDate) : base(datePart, startDate, endDate)
        {
        }
        #endregion

        #region as
        public new Int32DateDiffFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32DateDiffFunctionExpression obj)
            => obj is Int32DateDiffFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32DateDiffFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
