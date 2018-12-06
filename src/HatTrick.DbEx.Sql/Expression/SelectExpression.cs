using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectExpression : DbExpression, IDbExpressionSelectClausePart, IDbExpression, IAliasable, IAssemblyPart
    {
        #region internals
        private string _alias;
        #endregion

        #region interface
        public (Type, object) Expression { get; }
        public bool IsDistinct { get; private set; }
        string IAliasable.Alias => _alias;
        #endregion

        #region constructors
        internal SelectExpression(FieldExpression field)
        {
            Expression = (field.GetType(), field);
        }

        internal SelectExpression(ArithmeticExpression arithmeticExpression)
        {
            Expression = (arithmeticExpression.GetType(), arithmeticExpression);
        }

        internal SelectExpression(IDbFunctionExpression function)
        {
            Expression = (function.GetType(), function);
        }
        #endregion

        #region to string
        public override string ToString() => Expression.Item2.ToString() + (string.IsNullOrWhiteSpace(_alias) ? string.Empty : (" AS " + _alias));
        #endregion

        #region as
        public virtual SelectExpression As(string alias)
        {
            this._alias = alias;
            return this;
        }
        #endregion

        #region select to select arithmetic operators
        public static ArithmeticExpression operator +(SelectExpression a, SelectExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(SelectExpression a, SelectExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(SelectExpression a, SelectExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(SelectExpression a, SelectExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(SelectExpression a, SelectExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region select to value relational operators
        public static FilterExpression operator ==(SelectExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(SelectExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(SelectExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(SelectExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(SelectExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(SelectExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(SelectExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(SelectExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(SelectExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(SelectExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(SelectExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(SelectExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(SelectExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(SelectExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(SelectExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(SelectExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(SelectExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(SelectExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(SelectExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(SelectExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(SelectExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(SelectExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(SelectExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(SelectExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(SelectExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(SelectExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region select to select relational operators
        public static FilterExpression operator ==(SelectExpression a, SelectExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(SelectExpression a, SelectExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(SelectExpression a, SelectExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(SelectExpression a, SelectExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(SelectExpression a, SelectExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(SelectExpression a, SelectExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region logical & operator
        public static SelectExpressionSet operator &(SelectExpression a, SelectExpression b) => new SelectExpressionSet(a, b);
        #endregion

        #region implicit select expression set operator
        public static implicit operator SelectExpressionSet(SelectExpression a) => new SelectExpressionSet(a);
        #endregion

        #region implicit group by expression operator
        public static implicit operator GroupByExpression(SelectExpression a) => new GroupByExpression(a);
        #endregion

        #region equals
        public bool Equals(SelectExpression obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!ReferenceEquals(this.Expression.Item2, obj.Expression.Item2)) return false;
            if (string.Compare(this._alias, obj._alias) != 0) return false;
            if (this.IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SelectExpression other)) return false;
            return Equals(other);
        }

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
