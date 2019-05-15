using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public class GetDateFunctionExpression :
        IDbDateFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectFieldExpression<DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression, DateTime>,
        IEquatable<GetDateFunctionExpression>
    {

        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region as
        public GetDateFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "GETDATE()";
        #endregion

        #region equals
        public bool Equals(GetDateFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is GetDateFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(GetDateFunctionExpression a) => new SelectExpression(a);
        public static implicit operator GroupByExpression(GetDateFunctionExpression a) => new GroupByExpression(a);
        #endregion

        #region GetDate to arithmetic operators
        public static ArithmeticExpression operator +(GetDateFunctionExpression a, GetDateFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(GetDateFunctionExpression a, GetDateFunctionExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);
        #endregion

        #region GetDate to value relational operators
        public static FilterExpression operator ==(GetDateFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(GetDateFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(GetDateFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(GetDateFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(GetDateFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(GetDateFunctionExpression a, DateTime b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(GetDateFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(GetDateFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(GetDateFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(GetDateFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(GetDateFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(GetDateFunctionExpression a, DateTimeOffset b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region GetDate to GetDate relational operators
        public static FilterExpression operator ==(GetDateFunctionExpression a, GetDateFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(GetDateFunctionExpression a, GetDateFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(GetDateFunctionExpression a, GetDateFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(GetDateFunctionExpression a, GetDateFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(GetDateFunctionExpression a, GetDateFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(GetDateFunctionExpression a, GetDateFunctionExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
