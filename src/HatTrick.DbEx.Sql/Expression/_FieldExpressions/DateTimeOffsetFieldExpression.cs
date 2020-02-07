using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class DateTimeOffsetFieldExpression : FieldExpression<DateTimeOffset>,
        ISupportedForSelectFieldExpression<DateTimeOffset>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<CountFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, DateTimeOffset>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset>
    {
        protected DateTimeOffsetFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, DateTimeOffset>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected DateTimeOffsetFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, DateTimeOffset>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region DateTimeOffset
        public static ExpressionMediator<DateTimeOffset> operator +(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTimeOffset> operator +(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTimeOffset> operator +(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTimeOffset> operator +(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region mediator
        public static ExpressionMediator<DateTimeOffset> operator +(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(DateTimeOffsetFieldExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(DateTimeOffsetFieldExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(DateTimeOffsetFieldExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(DateTimeOffsetFieldExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(DateTimeOffsetFieldExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region DateTimeOffset
        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset? value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset? value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset? value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset? value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset? value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset? value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset value, DateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<DateTimeOffset?> operator ==(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(ExpressionMediator<DateTimeOffset> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(ExpressionMediator<DateTimeOffset> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(ExpressionMediator<DateTimeOffset> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(ExpressionMediator<DateTimeOffset> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(ExpressionMediator<DateTimeOffset> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(ExpressionMediator<DateTimeOffset> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(ExpressionMediator<DateTimeOffset?> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(ExpressionMediator<DateTimeOffset?> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(ExpressionMediator<DateTimeOffset?> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(ExpressionMediator<DateTimeOffset?> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(ExpressionMediator<DateTimeOffset?> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(ExpressionMediator<DateTimeOffset?> a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
