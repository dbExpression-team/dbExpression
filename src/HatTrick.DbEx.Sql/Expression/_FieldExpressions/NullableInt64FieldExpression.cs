using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableInt64FieldExpression : NullableFieldExpression<long>,
        ISupportedForSelectFieldExpression<long?>,
        ISupportedForFunctionExpression<CastFunctionExpression, long?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, long?>,
        ISupportedForFunctionExpression<NullableCastFunctionExpression, long?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>,
        ISupportedForFunctionExpression<CountFunctionExpression, long?>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, long?>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, long?>,
        ISupportedForFunctionExpression<AverageFunctionExpression, long?>,
        ISupportedForFunctionExpression<SumFunctionExpression, long?>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, long?>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, long?>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, long?>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, long?>
    {
        protected NullableInt64FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, long?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableInt64FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, long?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region long
        public static NullableExpressionMediator<long?> operator +(NullableInt64FieldExpression a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableInt64FieldExpression a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableInt64FieldExpression a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableInt64FieldExpression a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableInt64FieldExpression a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(long? a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(long? a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(long? a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(long? a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(long? a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(NullableInt64FieldExpression a, long b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableInt64FieldExpression a, long b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableInt64FieldExpression a, long b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableInt64FieldExpression a, long b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableInt64FieldExpression a, long b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(long a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(long a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(long a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(long a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(long a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region mediator
        public static NullableExpressionMediator<long?> operator +(NullableInt64FieldExpression a, ExpressionMediator<long> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableInt64FieldExpression a, ExpressionMediator<long> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableInt64FieldExpression a, ExpressionMediator<long> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableInt64FieldExpression a, ExpressionMediator<long> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableInt64FieldExpression a, ExpressionMediator<long> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(NullableInt64FieldExpression a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableInt64FieldExpression a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableInt64FieldExpression a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableInt64FieldExpression a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableInt64FieldExpression a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<long?> operator ==(NullableInt64FieldExpression field, DBNull value) => new FilterExpression<long?>(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(NullableInt64FieldExpression field, DBNull value) => new FilterExpression<long?>(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator ==(DBNull value, NullableInt64FieldExpression field) => new FilterExpression<long?>(value, field, FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(DBNull value, NullableInt64FieldExpression field) => new FilterExpression<long?>(value, field, FilterExpressionOperator.NotEqual);
        #endregion

        #region long
        public static FilterExpression<long?> operator ==(NullableInt64FieldExpression field, long? value) => new FilterExpression<long?>(field, new LiteralExpression<long?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(NullableInt64FieldExpression field, long? value) => new FilterExpression<long?>(field, new LiteralExpression<long?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator <(NullableInt64FieldExpression field, long? value) => new FilterExpression<long?>(field, new LiteralExpression<long?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<long?> operator <=(NullableInt64FieldExpression field, long? value) => new FilterExpression<long?>(field, new LiteralExpression<long?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<long?> operator >(NullableInt64FieldExpression field, long? value) => new FilterExpression<long?>(field, new LiteralExpression<long?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<long?> operator >=(NullableInt64FieldExpression field, long? value) => new FilterExpression<long?>(field, new LiteralExpression<long?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<long?> operator ==(long? value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(long? value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator <(long? value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<long?> operator <=(long? value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<long?> operator >(long? value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<long?> operator >=(long? value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<long?> operator ==(NullableInt64FieldExpression field, long value) => new FilterExpression<long?>(field, new LiteralExpression<long>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(NullableInt64FieldExpression field, long value) => new FilterExpression<long?>(field, new LiteralExpression<long>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator <(NullableInt64FieldExpression field, long value) => new FilterExpression<long?>(field, new LiteralExpression<long>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<long?> operator <=(NullableInt64FieldExpression field, long value) => new FilterExpression<long?>(field, new LiteralExpression<long>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<long?> operator >(NullableInt64FieldExpression field, long value) => new FilterExpression<long?>(field, new LiteralExpression<long>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<long?> operator >=(NullableInt64FieldExpression field, long value) => new FilterExpression<long?>(field, new LiteralExpression<long>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<long?> operator ==(long value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(long value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator <(long value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<long?> operator <=(long value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<long?> operator >(long value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<long?> operator >=(long value, NullableInt64FieldExpression field) => new FilterExpression<long?>(new LiteralExpression<long>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<long?> operator ==(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator <(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<long?> operator <=(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<long?> operator >(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<long?> operator >=(NullableInt64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<long?> operator ==(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator <(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<long?> operator <=(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<long?> operator >(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<long?> operator >=(NullableInt64FieldExpression a, Int64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<long?> operator ==(Int64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(Int64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator <(Int64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<long?> operator <=(Int64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<long?> operator >(Int64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<long?> operator >=(Int64FieldExpression a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<long?> operator ==(NullableInt64FieldExpression a, ExpressionMediator<long?> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(NullableInt64FieldExpression a, ExpressionMediator<long?> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator <(NullableInt64FieldExpression a, ExpressionMediator<long?> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<long?> operator <=(NullableInt64FieldExpression a, ExpressionMediator<long?> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<long?> operator >(NullableInt64FieldExpression a, ExpressionMediator<long?> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<long?> operator >=(NullableInt64FieldExpression a, ExpressionMediator<long?> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<long?> operator ==(ExpressionMediator<long?> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(ExpressionMediator<long?> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator <(ExpressionMediator<long?> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<long?> operator <=(ExpressionMediator<long?> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<long?> operator >(ExpressionMediator<long?> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<long?> operator >=(ExpressionMediator<long?> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<long?> operator ==(NullableInt64FieldExpression a, ExpressionMediator<long> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(NullableInt64FieldExpression a, ExpressionMediator<long> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator <(NullableInt64FieldExpression a, ExpressionMediator<long> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<long?> operator <=(NullableInt64FieldExpression a, ExpressionMediator<long> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<long?> operator >(NullableInt64FieldExpression a, ExpressionMediator<long> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<long?> operator >=(NullableInt64FieldExpression a, ExpressionMediator<long> b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<long?> operator ==(ExpressionMediator<long> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<long?> operator !=(ExpressionMediator<long> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<long?> operator <(ExpressionMediator<long> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<long?> operator <=(ExpressionMediator<long> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<long?> operator >(ExpressionMediator<long> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<long?> operator >=(ExpressionMediator<long> a, NullableInt64FieldExpression b) => new FilterExpression<long?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
