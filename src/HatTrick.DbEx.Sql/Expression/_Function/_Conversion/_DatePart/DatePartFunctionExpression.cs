using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DatePartFunctionExpression : ConversionFunctionExpression,
        IDbDateFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectExpression,
        IEquatable<DatePartFunctionExpression>
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public (Type, object) Expression { get; }
        public (Type, object) DatePart { get; private set; }
        string IDbExpressionAliasProvider.Alias => Alias;
        public OrderByExpression Asc => new OrderByExpression((GetType(), this), OrderExpressionDirection.ASC);
        public OrderByExpression Desc => new OrderByExpression((GetType(), this), OrderExpressionDirection.DESC);
        #endregion

        #region constructors
        protected DatePartFunctionExpression()
        {
        }

        protected DatePartFunctionExpression((Type, object) datePart, (Type, object) expression)
        {
            DatePart = datePart;
            Expression = expression;
        }
        #endregion

        #region as
        public DatePartFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => $"DATEPART({DatePart.ToString().ToLower()}, {Expression})";
        #endregion

        #region equals
        public bool Equals(DatePartFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (this.Expression == default && obj.Expression != default) return false;
            if (obj.Expression == default && this.Expression != default) return false;
            if (this.Expression.Item1 != obj.Expression.Item1) return false;
            if (this.Expression.Item2 != obj.Expression.Item2) return false;
            if (this.DatePart != obj.DatePart) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is DatePartFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator OrderByExpression(DatePartFunctionExpression datePart) => new OrderByExpression((datePart.GetType(), datePart), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DatePartFunctionExpression datePart) => new GroupByExpression((datePart.GetType(), datePart));
        #endregion
    }
}
