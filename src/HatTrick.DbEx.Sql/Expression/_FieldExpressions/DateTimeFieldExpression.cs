using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class DateTimeFieldExpression : FieldExpression<DateTime>,
        ISupportedForSelectFieldExpression<DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CountFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime>
    {
        protected DateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, DateTime>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected DateTimeFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, DateTime>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region DateTime
        public static ExpressionMediator<DateTime> operator +(DateTimeFieldExpression a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(DateTimeFieldExpression a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(DateTimeFieldExpression a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(DateTimeFieldExpression a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(DateTimeFieldExpression a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTime> operator +(DateTime a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(DateTime a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(DateTime a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(DateTime a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(DateTime a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTime> operator +(DateTimeFieldExpression a, DateTime? b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(DateTimeFieldExpression a, DateTime? b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(DateTimeFieldExpression a, DateTime? b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(DateTimeFieldExpression a, DateTime? b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(DateTimeFieldExpression a, DateTime? b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTime> operator +(DateTime? a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(DateTime? a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(DateTime? a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(DateTime? a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(DateTime? a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region mediator
        public static ExpressionMediator<DateTime> operator +(DateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(DateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(DateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(DateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(DateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(DateTimeFieldExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(DateTimeFieldExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(DateTimeFieldExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(DateTimeFieldExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(DateTimeFieldExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region DateTime
        public static FilterExpression<DateTime> operator ==(DateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(DateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(DateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(DateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(DateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(DateTimeFieldExpression field, DateTime? value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime? value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(DateTime? value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(DateTime? value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(DateTime? value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(DateTime? value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(DateTime? value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(DateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(DateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(DateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(DateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(DateTimeFieldExpression field, DateTime value) => new FilterExpression<DateTime>(field, new LiteralExpression<DateTime>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(DateTime value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(DateTime value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(DateTime value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(DateTime value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(DateTime value, DateTimeFieldExpression field) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<DateTime?> operator ==(DateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(DateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(DateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(DateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(DateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(DateTimeFieldExpression a, DateTimeFieldExpression b) => new FilterExpression<DateTime?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<DateTime> operator ==(DateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(DateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(DateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(DateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(DateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(DateTimeFieldExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(ExpressionMediator<DateTime> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(ExpressionMediator<DateTime> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(ExpressionMediator<DateTime> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(ExpressionMediator<DateTime> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(ExpressionMediator<DateTime> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(ExpressionMediator<DateTime> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(DateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(DateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(DateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(DateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(DateTimeFieldExpression a, ExpressionMediator<DateTime?> b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(ExpressionMediator<DateTime?> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(ExpressionMediator<DateTime?> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(ExpressionMediator<DateTime?> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(ExpressionMediator<DateTime?> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(ExpressionMediator<DateTime?> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(ExpressionMediator<DateTime?> a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
