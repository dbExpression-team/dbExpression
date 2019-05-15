using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public class SysUtcDateTimeFunctionExpression :
        IDbDateFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectFieldExpression<DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression, DateTime>,
        IEquatable<SysUtcDateTimeFunctionExpression>
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region as
        public SysUtcDateTimeFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "GetUtcDate()";
        #endregion

        #region equals
        public bool Equals(SysUtcDateTimeFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is SysUtcDateTimeFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(SysUtcDateTimeFunctionExpression a) => new SelectExpression(a);
        public static implicit operator GroupByExpression(SysUtcDateTimeFunctionExpression a) => new GroupByExpression(a);
        #endregion

        #region GetUtcDate to arithmetic operators
        public static ArithmeticExpression operator +(SysUtcDateTimeFunctionExpression a, SysUtcDateTimeFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(SysUtcDateTimeFunctionExpression a, SysUtcDateTimeFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);
        #endregion

        #region GetUtcDate to value relational operators
        public static FilterExpression operator ==(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(SysUtcDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(SysUtcDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(SysUtcDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(SysUtcDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(SysUtcDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(SysUtcDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(SysUtcDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region GetUtcDate to GetUtcDate relational operators
        public static FilterExpression operator ==(SysUtcDateTimeFunctionExpression a, SysUtcDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(SysUtcDateTimeFunctionExpression a, SysUtcDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(SysUtcDateTimeFunctionExpression a, SysUtcDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(SysUtcDateTimeFunctionExpression a, SysUtcDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(SysUtcDateTimeFunctionExpression a, SysUtcDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(SysUtcDateTimeFunctionExpression a, SysUtcDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
