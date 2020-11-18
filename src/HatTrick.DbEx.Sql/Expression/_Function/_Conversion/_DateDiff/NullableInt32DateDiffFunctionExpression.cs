using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32DateDiffFunctionExpression :
        NullableDateDiffFunctionExpression<int,int?>,
        NullInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32DateDiffFunctionExpression>
    {
        #region constructors
        public NullableInt32DateDiffFunctionExpression(DatePartsExpression datePart, IExpressionElement startDate, IExpressionElement endDate) 
            : base(datePart, startDate, endDate)
        {

        }

        protected NullableInt32DateDiffFunctionExpression(DatePartsExpression datePart, IExpressionElement startDate, IExpressionElement endDate, string alias)
            : base(datePart, startDate, endDate, alias)
        {

        }
        #endregion

        #region as
        public NullInt32Element As(string alias)
            => new NullableInt32DateDiffFunctionExpression(base.DatePart, base.StartDate, base.EndDate, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt32DateDiffFunctionExpression obj)
            => obj is NullableInt32DateDiffFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32DateDiffFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
