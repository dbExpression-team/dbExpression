using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class StringFieldExpression : FieldExpression<string>,
        ISupportedForSelectFieldExpression<string>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, string>,
        ISupportedForFunctionExpression<CastFunctionExpression, string>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, string>,
        ISupportedForFunctionExpression<CountFunctionExpression, string>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, string>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, string>,
        ISupportedForFunctionExpression<ConcatFunctionExpression, string>
    {
        protected StringFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, string>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected StringFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, string>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region like
        public FilterExpression Like(string phrase) => new FilterExpression<string>(this, new LiteralExpression<string>(phrase), FilterExpressionOperator.Like);
        #endregion

        #region arithmetic operators
        #region TValue
        public static ExpressionMediator<string> operator +(StringFieldExpression a, string b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<string> operator +(string a, StringFieldExpression b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(new LiteralExpression<string>(a), b, ArithmeticExpressionOperator.Add)));
        #endregion

        #region mediator
        public static ExpressionMediator<string> operator +(StringFieldExpression a, ExpressionMediator<string> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a, b.Expression, ArithmeticExpressionOperator.Add)));
        #endregion
        #endregion

        #region filter operators
        #region TValue
        public static FilterExpression<string> operator ==(StringFieldExpression field, string value) => new FilterExpression<string>(field, new LiteralExpression<string>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<string> operator !=(StringFieldExpression field, string value) => new FilterExpression<string>(field, new LiteralExpression<string>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<string> operator <(StringFieldExpression field, string value) => new FilterExpression<string>(field, new LiteralExpression<string>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<string> operator <=(StringFieldExpression field, string value) => new FilterExpression<string>(field, new LiteralExpression<string>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<string> operator >(StringFieldExpression field, string value) => new FilterExpression<string>(field, new LiteralExpression<string>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<string> operator >=(StringFieldExpression field, string value) => new FilterExpression<string>(field, new LiteralExpression<string>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<string> operator ==(string value, StringFieldExpression field) => new FilterExpression<string>(new LiteralExpression<string>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<string> operator !=(string value, StringFieldExpression field) => new FilterExpression<string>(new LiteralExpression<string>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<string> operator <(string value, StringFieldExpression field) => new FilterExpression<string>(new LiteralExpression<string>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<string> operator <=(string value, StringFieldExpression field) => new FilterExpression<string>(new LiteralExpression<string>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<string> operator >(string value, StringFieldExpression field) => new FilterExpression<string>(new LiteralExpression<string>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<string> operator >=(string value, StringFieldExpression field) => new FilterExpression<string>(new LiteralExpression<string>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<string> operator ==(StringFieldExpression a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<string> operator !=(StringFieldExpression a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<string> operator <(StringFieldExpression a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<string> operator <=(StringFieldExpression a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<string> operator >(StringFieldExpression a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<string> operator >=(StringFieldExpression a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<string> operator ==(StringFieldExpression a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<string> operator !=(StringFieldExpression a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<string> operator <(StringFieldExpression a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<string> operator <=(StringFieldExpression a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<string> operator >(StringFieldExpression a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<string> operator >=(StringFieldExpression a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<string> operator ==(ExpressionMediator<string> a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<string> operator !=(ExpressionMediator<string> a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<string> operator <(ExpressionMediator<string> a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<string> operator <=(ExpressionMediator<string> a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<string> operator >(ExpressionMediator<string> a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<string> operator >=(ExpressionMediator<string> a, StringFieldExpression b) => new FilterExpression<string>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
