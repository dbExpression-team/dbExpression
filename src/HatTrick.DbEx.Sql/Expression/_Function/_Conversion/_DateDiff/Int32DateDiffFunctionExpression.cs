using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32DateDiffFunctionExpression :
        DateDiffFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32DateDiffFunctionExpression>
    {
        #region constructors
        public Int32DateDiffFunctionExpression(DatePartsExpression datePart, DateTimeElement startDate, DateTimeElement endDate) : base(datePart, startDate, endDate)
        {

        }

        public Int32DateDiffFunctionExpression(DatePartsExpression datePart, DateTimeElement startDate, DateTimeOffsetElement endDate) : base(datePart, startDate, endDate)
        {

        }

        public Int32DateDiffFunctionExpression(DatePartsExpression datePart, DateTimeOffsetElement startDate, DateTimeElement endDate) : base(datePart, startDate, endDate)
        {

        }

        public Int32DateDiffFunctionExpression(DatePartsExpression datePart, DateTimeOffsetElement startDate, DateTimeOffsetElement endDate) : base(datePart, startDate, endDate)
        {

        }

        protected Int32DateDiffFunctionExpression(DatePartsExpression datePart, IExpressionElement startDate, IExpressionElement endDate, string alias) : base(datePart, startDate, endDate, alias)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
            => new Int32DateDiffFunctionExpression(base.DatePart, base.StartDate, base.EndDate, alias);
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
