using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DateDiffFunctionExpression : ConversionFunctionExpression,
        IEquatable<DateDiffFunctionExpression>
    {
        #region interface
        public DatePartsExpression DatePart { get; private set; }
        public IExpressionElement StartDate => base.Expression;
        public IExpressionElement EndDate { get; private set; }
        #endregion

        #region constructors
        protected DateDiffFunctionExpression(DatePartsExpression datePart, IExpressionElement startDate, IExpressionElement endDate, Type convertToType)
            : base(startDate, convertToType)
        {
            DatePart = datePart ?? throw new ArgumentNullException($"{nameof(datePart)} is required.");
            EndDate = endDate ?? throw new ArgumentNullException($"{nameof(endDate)} is required.");
        }
        #endregion

        #region to string
        public override string ToString() => $"DATEDIFF({DatePart.ToString().ToLower()}, {StartDate}, {EndDate})";
        #endregion

        #region equals
        public bool Equals(DateDiffFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (StartDate is null && obj.StartDate is object) return false;
            if (StartDate is object && obj.StartDate is null) return false;
            if (!StartDate.Equals(obj.StartDate)) return false;

            if (EndDate is null && obj.EndDate is object) return false;
            if (EndDate is object && obj.EndDate is null) return false;
            if (!EndDate.Equals(obj.EndDate)) return false;

            if (DatePart is null && obj.DatePart is object) return false;
            if (DatePart is object && obj.DatePart is null) return false;
            if (!DatePart.Equals(obj.DatePart)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is DateDiffFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (StartDate is object ? StartDate.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (EndDate is object ? EndDate.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (DatePart is object ? DatePart.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
