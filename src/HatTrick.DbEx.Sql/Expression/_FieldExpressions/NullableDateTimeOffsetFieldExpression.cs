using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableDateTimeOffsetFieldExpression : NullableFieldExpression<DateTimeOffset>,
        ISupportedForSelectFieldExpression<DateTimeOffset?>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTimeOffset?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTimeOffset?>,
        ISupportedForFunctionExpression<NullableCastFunctionExpression, DateTimeOffset?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>,
        ISupportedForFunctionExpression<CountFunctionExpression, DateTimeOffset?>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, DateTimeOffset?>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, DateTimeOffset?>,
        ISupportedForFunctionExpression<IDbNullableDateFunctionExpression, DateTimeOffset?>
    {
        protected NullableDateTimeOffsetFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, DateTimeOffset?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableDateTimeOffsetFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, DateTimeOffset?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region DateTimeOffset
        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableDateTimeOffsetFieldExpression a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableDateTimeOffsetFieldExpression a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableDateTimeOffsetFieldExpression a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableDateTimeOffsetFieldExpression a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableDateTimeOffsetFieldExpression a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(DateTimeOffset? a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(DateTimeOffset? a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(DateTimeOffset? a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(DateTimeOffset? a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(DateTimeOffset? a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableDateTimeOffsetFieldExpression a, DateTimeOffset b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableDateTimeOffsetFieldExpression a, DateTimeOffset b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableDateTimeOffsetFieldExpression a, DateTimeOffset b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableDateTimeOffsetFieldExpression a, DateTimeOffset b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableDateTimeOffsetFieldExpression a, DateTimeOffset b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(DateTimeOffset a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(DateTimeOffset a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(DateTimeOffset a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(DateTimeOffset a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(DateTimeOffset a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region mediator
        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableDateTimeOffsetFieldExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableDateTimeOffsetFieldExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableDateTimeOffsetFieldExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableDateTimeOffsetFieldExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableDateTimeOffsetFieldExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<DateTimeOffset?> operator ==(NullableDateTimeOffsetFieldExpression field, DBNull value) => new FilterExpression<DateTimeOffset?>(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(NullableDateTimeOffsetFieldExpression field, DBNull value) => new FilterExpression<DateTimeOffset?>(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(DBNull value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(value, field, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(DBNull value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(value, field, FilterExpressionOperator.NotEqual);
        #endregion

        #region DateTimeOffset
        public static FilterExpression<DateTimeOffset?> operator ==(NullableDateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(NullableDateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(NullableDateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(NullableDateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(NullableDateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(NullableDateTimeOffsetFieldExpression field, DateTimeOffset? value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(DateTimeOffset? value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(DateTimeOffset? value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(DateTimeOffset? value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(DateTimeOffset? value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(DateTimeOffset? value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(DateTimeOffset? value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(NullableDateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(NullableDateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(NullableDateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(NullableDateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(NullableDateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(NullableDateTimeOffsetFieldExpression field, DateTimeOffset value) => new FilterExpression<DateTimeOffset?>(field, new LiteralExpression<DateTimeOffset>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(DateTimeOffset value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(DateTimeOffset value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(DateTimeOffset value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(DateTimeOffset value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(DateTimeOffset value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(DateTimeOffset value, NullableDateTimeOffsetFieldExpression field) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<DateTimeOffset?> operator ==(NullableDateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(NullableDateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(NullableDateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(NullableDateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(NullableDateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(NullableDateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(NullableDateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(NullableDateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(NullableDateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(NullableDateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(NullableDateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(NullableDateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<DateTimeOffset?> operator ==(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(ExpressionMediator<DateTimeOffset?> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(ExpressionMediator<DateTimeOffset?> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(ExpressionMediator<DateTimeOffset?> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(ExpressionMediator<DateTimeOffset?> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(ExpressionMediator<DateTimeOffset?> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(ExpressionMediator<DateTimeOffset?> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(ExpressionMediator<DateTimeOffset> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(ExpressionMediator<DateTimeOffset> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(ExpressionMediator<DateTimeOffset> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(ExpressionMediator<DateTimeOffset> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(ExpressionMediator<DateTimeOffset> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(ExpressionMediator<DateTimeOffset> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
