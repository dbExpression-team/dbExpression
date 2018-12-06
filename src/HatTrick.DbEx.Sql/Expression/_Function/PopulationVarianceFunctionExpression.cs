using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class PopulationVarianceFunctionExpression :
        IDbFunctionExpression,
        IAssemblyPart,
        IDbExpressionSelectClausePart,
        IEquatable<PopulationVarianceFunctionExpression>
    {
        #region interface
        public (Type, object) Expression { get; }
        public bool IsDistinct { get; }
        #endregion

        #region constructors
        internal PopulationVarianceFunctionExpression()
        {
        }

        public PopulationVarianceFunctionExpression(IDbExpressionSelectClausePart expression, bool isDistinct)
        {
            Expression = (expression.GetType(), expression);
            IsDistinct = isDistinct;
        }
        #endregion

        #region as
        public SelectExpression As(string alias) => new SelectExpression(this).As(alias);
        #endregion

        #region to string
        public override string ToString() => $"VARP({(IsDistinct ? "DISTINCT " : string.Empty)}{Expression})";
        #endregion

        #region equals
        public bool Equals(PopulationVarianceFunctionExpression obj)
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
            => obj is PopulationVarianceFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(PopulationVarianceFunctionExpression a) => new SelectExpression(a);
        #endregion

        #region population variance to arithmetic operators
        public static ArithmeticExpression operator +(PopulationVarianceFunctionExpression a, PopulationVarianceFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(PopulationVarianceFunctionExpression a, PopulationVarianceFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(PopulationVarianceFunctionExpression a, PopulationVarianceFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(PopulationVarianceFunctionExpression a, PopulationVarianceFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(PopulationVarianceFunctionExpression a, PopulationVarianceFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region population variance to value relational operators
        public static FilterExpression operator ==(PopulationVarianceFunctionExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(PopulationVarianceFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(PopulationVarianceFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(PopulationVarianceFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(PopulationVarianceFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(PopulationVarianceFunctionExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(PopulationVarianceFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(PopulationVarianceFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(PopulationVarianceFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(PopulationVarianceFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(PopulationVarianceFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(PopulationVarianceFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(PopulationVarianceFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(PopulationVarianceFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(PopulationVarianceFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(PopulationVarianceFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(PopulationVarianceFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(PopulationVarianceFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(PopulationVarianceFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(PopulationVarianceFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(PopulationVarianceFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(PopulationVarianceFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(PopulationVarianceFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(PopulationVarianceFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(PopulationVarianceFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(PopulationVarianceFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region population variance to population variance relational operators
        public static FilterExpression operator ==(PopulationVarianceFunctionExpression a, PopulationVarianceFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(PopulationVarianceFunctionExpression a, PopulationVarianceFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(PopulationVarianceFunctionExpression a, PopulationVarianceFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(PopulationVarianceFunctionExpression a, PopulationVarianceFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(PopulationVarianceFunctionExpression a, PopulationVarianceFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(PopulationVarianceFunctionExpression a, PopulationVarianceFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
