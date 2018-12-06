using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class SumFunctionExpression :
        IDbFunctionExpression,
        IAssemblyPart,
        IDbExpressionSelectClausePart,
        IEquatable<SumFunctionExpression>
    {
        #region interface
        public (Type, object) Expression { get; }
        public bool IsDistinct { get; }
        #endregion

        #region constructors
        internal SumFunctionExpression()
        {
        }

        public SumFunctionExpression(IDbExpressionSelectClausePart<byte> expression, bool isDistinct)
        {
            Expression = (expression.GetType(), expression);
            IsDistinct = isDistinct;
        }

        public SumFunctionExpression(IDbExpressionSelectClausePart<short> expression, bool isDistinct)
        {
            Expression = (expression.GetType(), expression);
            IsDistinct = isDistinct;
        }

        public SumFunctionExpression(IDbExpressionSelectClausePart<int> expression, bool isDistinct)
        {
            Expression = (expression.GetType(), expression);
            IsDistinct = isDistinct;
        }

        public SumFunctionExpression(IDbExpressionSelectClausePart<long> expression, bool isDistinct)
        {
            Expression = (expression.GetType(), expression);
            IsDistinct = isDistinct;
        }

        public SumFunctionExpression(IDbExpressionSelectClausePart<decimal> expression, bool isDistinct)
        {
            Expression = (expression.GetType(), expression);
            IsDistinct = isDistinct;
        }

        public SumFunctionExpression(IDbExpressionSelectClausePart<double> expression, bool isDistinct)
        {
            Expression = (expression.GetType(), expression);
            IsDistinct = isDistinct;
        }

        public SumFunctionExpression(IDbExpressionSelectClausePart<float> expression, bool isDistinct)
        {
            Expression = (expression.GetType(), expression);
            IsDistinct = isDistinct;
        }
        #endregion

        #region as
        public SelectExpression As(string alias) => new SelectExpression(this).As(alias);
        #endregion

        #region to string
        public override string ToString() => $"SUM({(IsDistinct ? "DISTINCT " : string.Empty)}{Expression})";
        #endregion

        #region equals
        public bool Equals(SumFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (this.Expression == default && obj.Expression != default) return false;
            if (obj.Expression == default && this.Expression != default) return false;
            if (this.Expression.Item1 != obj.Expression.Item1) return false;
            if (this.Expression.Item2 != obj.Expression.Item2) return false;
            if (this.IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is SumFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(SumFunctionExpression a) => new SelectExpression(a);
        #endregion

        #region sum to arithmetic operators
        public static ArithmeticExpression operator +(SumFunctionExpression a, SumFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(SumFunctionExpression a, SumFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(SumFunctionExpression a, SumFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(SumFunctionExpression a, SumFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(SumFunctionExpression a, SumFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region sum to value relational operators
        public static FilterExpression operator ==(SumFunctionExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(SumFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(SumFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(SumFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(SumFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(SumFunctionExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(SumFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(SumFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(SumFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(SumFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(SumFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(SumFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(SumFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(SumFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(SumFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(SumFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(SumFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(SumFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(SumFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(SumFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(SumFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(SumFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(SumFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(SumFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(SumFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(SumFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region sum to sum relational operators
        public static FilterExpression operator ==(SumFunctionExpression a, SumFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(SumFunctionExpression a, SumFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(SumFunctionExpression a, SumFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(SumFunctionExpression a, SumFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(SumFunctionExpression a, SumFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(SumFunctionExpression a, SumFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
