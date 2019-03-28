using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class PopulationStandardDeviationFunctionExpression :
        IDbNumericalFunctionExpression,
        IAssemblyPart,
        IDbExpressionIsDistinctProvider,
        IDbExpressionAliasProvider,
        IEquatable<PopulationStandardDeviationFunctionExpression>,
        ISupportedForSelectExpression
    {
        #region internals
        protected bool IsDistinct { get; private set; }
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public (Type, object) Expression { get; }
        bool IDbExpressionIsDistinctProvider.IsDistinct => IsDistinct;
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        internal PopulationStandardDeviationFunctionExpression()
        {
        }

        public PopulationStandardDeviationFunctionExpression(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression> expression, bool isDistinct)
        {
            Expression = (expression.GetType(), expression);
            IsDistinct = isDistinct;
        }
        #endregion

        #region as
        public PopulationStandardDeviationFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => $"STDEVP({(IsDistinct ? "DISTINCT " : string.Empty)}{Expression})";
        #endregion

        #region equals
        public bool Equals(PopulationStandardDeviationFunctionExpression obj)
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
            => obj is PopulationStandardDeviationFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(PopulationStandardDeviationFunctionExpression a) => new SelectExpression(a);
        #endregion

        #region population standard deviation to arithmetic operators
        public static ArithmeticExpression operator +(PopulationStandardDeviationFunctionExpression a, PopulationStandardDeviationFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(PopulationStandardDeviationFunctionExpression a, PopulationStandardDeviationFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(PopulationStandardDeviationFunctionExpression a, PopulationStandardDeviationFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(PopulationStandardDeviationFunctionExpression a, PopulationStandardDeviationFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(PopulationStandardDeviationFunctionExpression a, PopulationStandardDeviationFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region population standard deviation to value relational operators
        public static FilterExpression operator ==(PopulationStandardDeviationFunctionExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(PopulationStandardDeviationFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(PopulationStandardDeviationFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(PopulationStandardDeviationFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(PopulationStandardDeviationFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(PopulationStandardDeviationFunctionExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(PopulationStandardDeviationFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(PopulationStandardDeviationFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(PopulationStandardDeviationFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(PopulationStandardDeviationFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(PopulationStandardDeviationFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(PopulationStandardDeviationFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(PopulationStandardDeviationFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(PopulationStandardDeviationFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(PopulationStandardDeviationFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(PopulationStandardDeviationFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(PopulationStandardDeviationFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(PopulationStandardDeviationFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(PopulationStandardDeviationFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(PopulationStandardDeviationFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(PopulationStandardDeviationFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(PopulationStandardDeviationFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(PopulationStandardDeviationFunctionExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(PopulationStandardDeviationFunctionExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(PopulationStandardDeviationFunctionExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(PopulationStandardDeviationFunctionExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region population standard deviation to population standard deviation relational operators
        public static FilterExpression operator ==(PopulationStandardDeviationFunctionExpression a, PopulationStandardDeviationFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(PopulationStandardDeviationFunctionExpression a, PopulationStandardDeviationFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(PopulationStandardDeviationFunctionExpression a, PopulationStandardDeviationFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(PopulationStandardDeviationFunctionExpression a, PopulationStandardDeviationFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(PopulationStandardDeviationFunctionExpression a, PopulationStandardDeviationFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(PopulationStandardDeviationFunctionExpression a, PopulationStandardDeviationFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
