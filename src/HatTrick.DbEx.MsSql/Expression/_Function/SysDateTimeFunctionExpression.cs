using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public class SysDateTimeFunctionExpression :
        IDbDateFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectFieldExpression<DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression, DateTime>,
        IEquatable<SysDateTimeFunctionExpression>
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region as
        public SysDateTimeFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "SysDateTime()";
        #endregion

        #region equals
        public bool Equals(SysDateTimeFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is SysDateTimeFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(SysDateTimeFunctionExpression a) => new SelectExpression(a);
        public static implicit operator GroupByExpression(SysDateTimeFunctionExpression a) => new GroupByExpression(a);
        #endregion

        #region SysDateTime to arithmetic operators
        public static ArithmeticExpression operator +(SysDateTimeFunctionExpression a, SysDateTimeFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(SysDateTimeFunctionExpression a, SysDateTimeFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);
        #endregion

        #region SysDateTime to value relational operators
        public static FilterExpression operator ==(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region SysDateTime to SysDateTime relational operators
        public static FilterExpression operator ==(SysDateTimeFunctionExpression a, SysDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(SysDateTimeFunctionExpression a, SysDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(SysDateTimeFunctionExpression a, SysDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(SysDateTimeFunctionExpression a, SysDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(SysDateTimeFunctionExpression a, SysDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(SysDateTimeFunctionExpression a, SysDateTimeFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
