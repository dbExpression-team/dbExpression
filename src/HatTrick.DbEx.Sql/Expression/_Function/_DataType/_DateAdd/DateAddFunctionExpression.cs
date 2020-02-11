using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DateAddFunctionExpression : DataTypeFunctionExpression,
        IDbDateFunctionExpression,
        IAssemblyPart,
        ISupportedForSelectExpression,
        IEquatable<DateAddFunctionExpression>
    {
        #region interface
        public (Type, object) DatePart { get; private set; }
        public (Type, object) Value { get; private set; }
        #endregion

        #region constructors
        protected DateAddFunctionExpression()
        {
        }

        protected DateAddFunctionExpression((Type, object) datePart, (Type, object) value, (Type, object) expression)
            : base(expression)
        {
            DatePart = datePart;
            Value = value;
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

            if (this.DatePart == default && obj.DatePart != default) return false;
            if (obj.DatePart == default && this.DatePart != default) return false;
            if (this.DatePart.Item1 != obj.DatePart.Item1) return false;
            if (this.DatePart.Item2 != obj.DatePart.Item2) return false;

            if (this.Value != obj.Value) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is DateAddFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
