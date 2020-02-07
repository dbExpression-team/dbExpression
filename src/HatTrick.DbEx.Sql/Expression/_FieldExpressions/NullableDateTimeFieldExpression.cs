using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableDateTimeFieldExpression : NullableFieldExpression<DateTime>,
        ISupportedForSelectFieldExpression<DateTime?>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime?>,
        ISupportedForFunctionExpression<NullableCastFunctionExpression, DateTime?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>,
        ISupportedForFunctionExpression<CountFunctionExpression, DateTime?>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, DateTime?>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, DateTime?>,
        ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?>
    {
        protected NullableDateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, DateTime?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableDateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, DateTime?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region DateTime
        public static NullableExpressionMediator<DateTime?> operator +(NullableDateTimeFieldExpression a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableDateTimeFieldExpression a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableDateTimeFieldExpression a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableDateTimeFieldExpression a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableDateTimeFieldExpression a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(DateTime? a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(DateTime? a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(DateTime? a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(DateTime? a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(DateTime? a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(NullableDateTimeFieldExpression a, DateTime b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableDateTimeFieldExpression a, DateTime b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableDateTimeFieldExpression a, DateTime b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableDateTimeFieldExpression a, DateTime b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableDateTimeFieldExpression a, DateTime b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(DateTime a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(DateTime a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(DateTime a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(DateTime a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(DateTime a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region mediator
        public static NullableExpressionMediator<DateTime?> operator +(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(NullableDateTimeFieldExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableDateTimeFieldExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableDateTimeFieldExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableDateTimeFieldExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableDateTimeFieldExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression field, DBNull value) => new FilterExpression<DateTime?>(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression field, DBNull value) => new FilterExpression<DateTime?>(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator ==(DBNull value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(value, field, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(DBNull value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(value, field, FilterExpressionOperator.NotEqual);
        #endregion

        #region DateTime
        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(NullableDateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(NullableDateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(NullableDateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(NullableDateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(DateTime? value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(DateTime? value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(DateTime? value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(DateTime? value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(DateTime? value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(DateTime? value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(NullableDateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(NullableDateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(NullableDateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(NullableDateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime?>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(DateTime value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(DateTime value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(DateTime value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(DateTime value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(DateTime value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(DateTime value, NullableDateTimeFieldExpression field) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(DateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(DateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(DateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(DateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(DateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(DateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(ExpressionMediator<DateTime?> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(ExpressionMediator<DateTime?> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(ExpressionMediator<DateTime?> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(ExpressionMediator<DateTime?> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(ExpressionMediator<DateTime?> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(ExpressionMediator<DateTime?> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(NullableDateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(ExpressionMediator<DateTime> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(ExpressionMediator<DateTime> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(ExpressionMediator<DateTime> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(ExpressionMediator<DateTime> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(ExpressionMediator<DateTime> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(ExpressionMediator<DateTime> a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
