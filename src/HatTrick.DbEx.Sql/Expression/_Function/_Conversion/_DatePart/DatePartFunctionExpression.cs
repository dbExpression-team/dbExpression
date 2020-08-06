using System;
using System.Runtime.CompilerServices;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DatePartFunctionExpression : ConversionFunctionExpression,
        IDateFunctionExpression,
        IEquatable<DatePartFunctionExpression>
    {
        #region interface
        public ExpressionContainer DatePart { get; private set; }
        #endregion

        #region constructors
        protected DatePartFunctionExpression(ExpressionContainer datePart, ExpressionMediator expression) : base(expression)
        {
            DatePart = datePart ?? throw new ArgumentNullException($"{nameof(datePart)} is required.");
        }
        #endregion

        #region as
        public new DatePartFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => $"DATEPART({DatePart.ToString().ToLower()}, {Expression})";
        #endregion

        #region equals
        public bool Equals(DatePartFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (this.DatePart is null && obj.DatePart is object) return false;
            if (this.DatePart is object && obj.DatePart is null) return false;
            if (!this.DatePart.Equals(obj.DatePart)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is DatePartFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (DatePart is object ? DatePart.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region implicit operators
        public static implicit operator GroupByExpression(DatePartFunctionExpression datePart) => new GroupByExpression(new Int32ExpressionMediator(datePart));
        #endregion
    }
}
