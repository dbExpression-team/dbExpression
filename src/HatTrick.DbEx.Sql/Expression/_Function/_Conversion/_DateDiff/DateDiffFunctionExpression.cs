using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DateDiffFunctionExpression : ConversionFunctionExpression,
        IDbDateFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForFunctionExpression<IsNullFunctionExpression, int>,
        ISupportedForFunctionExpression<CastFunctionExpression, int>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, int>,
        ISupportedForFunctionExpression<AverageFunctionExpression, int>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, int>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, int>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression>,
        IEquatable<DateDiffFunctionExpression>
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public (Type, object) DatePart { get; private set; }
        public (Type, object) StartDate { get; private set; }
        public (Type, object) EndDate { get; private set; }
        string IDbExpressionAliasProvider.Alias => Alias;
        public OrderByExpression Asc => new OrderByExpression((GetType(), this), OrderExpressionDirection.ASC);
        public OrderByExpression Desc => new OrderByExpression((GetType(), this), OrderExpressionDirection.DESC);
        #endregion

        #region constructors
        protected DateDiffFunctionExpression()
        {
        }

        protected DateDiffFunctionExpression((Type, object) datePart, (Type, object) startDate, (Type, object) endDate)
        {
            DatePart = datePart;
            StartDate = startDate;
            EndDate = endDate;
        }
        #endregion

        #region as
        public DateDiffFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => $"DATEDIFF({DatePart.ToString().ToLower()}, {StartDate.Item2}, {EndDate.Item2})";
        #endregion

        #region equals
        public bool Equals(DateDiffFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            if (this.StartDate == default && obj.StartDate != default) return false;
            if (obj.StartDate == default && this.StartDate != default) return false;
            if (this.StartDate.Item1 != obj.StartDate.Item1) return false;
            if (this.StartDate.Item2 != obj.StartDate.Item2) return false;

            if (this.EndDate == default && obj.EndDate != default) return false;
            if (obj.EndDate == default && this.EndDate != default) return false;
            if (this.EndDate.Item1 != obj.EndDate.Item1) return false;
            if (this.EndDate.Item2 != obj.EndDate.Item2) return false;

            if (this.DatePart != obj.DatePart) return false;

            if (this.Alias != obj.Alias) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is DateDiffFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator OrderByExpression(DateDiffFunctionExpression dateDiff) => new OrderByExpression((dateDiff.GetType(), dateDiff), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DateDiffFunctionExpression dateDiff) => new GroupByExpression((dateDiff.GetType(), dateDiff));
        #endregion
    }
}
