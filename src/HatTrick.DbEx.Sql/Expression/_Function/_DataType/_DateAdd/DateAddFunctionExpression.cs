using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DateAddFunctionExpression : DataTypeFunctionExpression,
        IDbDateFunctionExpression,
        IEquatable<DateAddFunctionExpression>
    {
        #region interface
        public ExpressionContainer DatePart { get; private set; }
        public ExpressionContainer Value { get; private set; }
        #endregion

        #region constructors
        protected DateAddFunctionExpression(ExpressionContainer datePart, ExpressionContainer value, ExpressionContainer expression) : base(expression)
        {
            DatePart = datePart ?? throw new ArgumentNullException($"{nameof(datePart)} is required.");
            Value = value ?? throw new ArgumentNullException($"{nameof(value)} is required.");
        }
        #endregion

        #region as
        public new DateAddFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => $"DateAdd({Expression})";
        #endregion

        #region equals
        public bool Equals(DateAddFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (this.DatePart is null && obj.DatePart is object) return false;
            if (this.DatePart is object && obj.DatePart is null) return false;
            if (!this.DatePart.Equals(obj.DatePart)) return false;

            if (this.Value is null && obj.Value is object) return false;
            if (this.Value is object && obj.Value is null) return false;
            if (!this.Value.Equals(obj.Value)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is DateAddFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (DatePart is object ? DatePart.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Value is object ? Value.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
