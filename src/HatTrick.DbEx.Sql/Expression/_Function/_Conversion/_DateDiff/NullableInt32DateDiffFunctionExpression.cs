using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32DateDiffFunctionExpression :
        NullableDateDiffFunctionExpression<int>,
        IEquatable<NullableInt32DateDiffFunctionExpression>
    {
        #region constructors
        public NullableInt32DateDiffFunctionExpression(ExpressionContainer datePart, ExpressionContainer startDate, ExpressionContainer endDate) : base(datePart, startDate, endDate)
        {
        }
        #endregion

        #region as
        public new NullableInt32DateDiffFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
