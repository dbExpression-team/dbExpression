using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DateDiffFunctionExpression : ConversionFunctionExpression,
        IDbDateFunctionExpression,
        IDbExpressionAliasProvider,
        IEquatable<DateDiffFunctionExpression>
    {
        #region interface
        public ExpressionContainer DatePart { get; private set; }
        public ExpressionMediator StartDate { get; private set; }
        public ExpressionMediator EndDate { get; private set; }
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected DateDiffFunctionExpression(ExpressionContainer datePart, ExpressionMediator startDate, ExpressionMediator endDate)
        {
            DatePart = datePart ?? throw new ArgumentNullException($"{nameof(datePart)} is required.");
            StartDate = startDate ?? throw new ArgumentNullException($"{nameof(startDate)} is required.");
            EndDate = endDate ?? throw new ArgumentNullException($"{nameof(endDate)} is required.");
        }
        #endregion

        #region as
        public new DateDiffFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
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
