using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableFloatFieldExpression : NullableFieldExpression<float>,
        ISupportedForSelectFieldExpression<float?>,
        ISupportedForFunctionExpression<CastFunctionExpression, float?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, float?>,
        ISupportedForFunctionExpression<NullableCastFunctionExpression, float?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>,
        ISupportedForFunctionExpression<CountFunctionExpression, float?>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, float?>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, float?>,
        ISupportedForFunctionExpression<AverageFunctionExpression, float?>,
        ISupportedForFunctionExpression<SumFunctionExpression, float?>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, float?>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, float?>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, float?>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, float?>
    {
        protected NullableFloatFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, float?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableFloatFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, float?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region float
        public static NullableExpressionMediator<float?> operator +(NullableFloatFieldExpression a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableFloatFieldExpression a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableFloatFieldExpression a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableFloatFieldExpression a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableFloatFieldExpression a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(float? a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(float? a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(float? a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(float? a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(float? a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(NullableFloatFieldExpression a, float b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableFloatFieldExpression a, float b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableFloatFieldExpression a, float b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableFloatFieldExpression a, float b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableFloatFieldExpression a, float b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(float a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(float a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(float a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(float a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(float a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region mediator
        public static NullableExpressionMediator<float?> operator +(NullableFloatFieldExpression a, ExpressionMediator<float> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableFloatFieldExpression a, ExpressionMediator<float> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableFloatFieldExpression a, ExpressionMediator<float> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableFloatFieldExpression a, ExpressionMediator<float> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableFloatFieldExpression a, ExpressionMediator<float> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(NullableFloatFieldExpression a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableFloatFieldExpression a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableFloatFieldExpression a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableFloatFieldExpression a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableFloatFieldExpression a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<float?> operator ==(NullableFloatFieldExpression field, DBNull value) => new FilterExpression<float?>(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(NullableFloatFieldExpression field, DBNull value) => new FilterExpression<float?>(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator ==(DBNull value, NullableFloatFieldExpression field) => new FilterExpression<float?>(value, field, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(DBNull value, NullableFloatFieldExpression field) => new FilterExpression<float?>(value, field, FilterExpressionOperator.NotEqual);
        #endregion

        #region float
        public static FilterExpression<float?> operator ==(NullableFloatFieldExpression field, float? value) => new FilterExpression<float?>(field, new LiteralExpression<float?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(NullableFloatFieldExpression field, float? value) => new FilterExpression<float?>(field, new LiteralExpression<float?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(NullableFloatFieldExpression field, float? value) => new FilterExpression<float?>(field, new LiteralExpression<float?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(NullableFloatFieldExpression field, float? value) => new FilterExpression<float?>(field, new LiteralExpression<float?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(NullableFloatFieldExpression field, float? value) => new FilterExpression<float?>(field, new LiteralExpression<float?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(NullableFloatFieldExpression field, float? value) => new FilterExpression<float?>(field, new LiteralExpression<float?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(float? value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(float? value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(float? value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(float? value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(float? value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(float? value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(NullableFloatFieldExpression field, float value) => new FilterExpression<float?>(field, new LiteralExpression<float>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(NullableFloatFieldExpression field, float value) => new FilterExpression<float?>(field, new LiteralExpression<float>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(NullableFloatFieldExpression field, float value) => new FilterExpression<float?>(field, new LiteralExpression<float>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(NullableFloatFieldExpression field, float value) => new FilterExpression<float?>(field, new LiteralExpression<float>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(NullableFloatFieldExpression field, float value) => new FilterExpression<float?>(field, new LiteralExpression<float>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(NullableFloatFieldExpression field, float value) => new FilterExpression<float?>(field, new LiteralExpression<float>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(float value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(float value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(float value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(float value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(float value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(float value, NullableFloatFieldExpression field) => new FilterExpression<float?>(new LiteralExpression<float>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<float?> operator ==(NullableFloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(NullableFloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(NullableFloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(NullableFloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(NullableFloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(NullableFloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(NullableFloatFieldExpression a, FloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(NullableFloatFieldExpression a, FloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(NullableFloatFieldExpression a, FloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(NullableFloatFieldExpression a, FloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(NullableFloatFieldExpression a, FloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(NullableFloatFieldExpression a, FloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(FloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(FloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(FloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(FloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(FloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(FloatFieldExpression a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<float?> operator ==(NullableFloatFieldExpression a, ExpressionMediator<float?> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(NullableFloatFieldExpression a, ExpressionMediator<float?> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(NullableFloatFieldExpression a, ExpressionMediator<float?> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(NullableFloatFieldExpression a, ExpressionMediator<float?> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(NullableFloatFieldExpression a, ExpressionMediator<float?> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(NullableFloatFieldExpression a, ExpressionMediator<float?> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(ExpressionMediator<float?> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(ExpressionMediator<float?> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(ExpressionMediator<float?> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(ExpressionMediator<float?> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(ExpressionMediator<float?> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(ExpressionMediator<float?> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(NullableFloatFieldExpression a, ExpressionMediator<float> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(NullableFloatFieldExpression a, ExpressionMediator<float> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(NullableFloatFieldExpression a, ExpressionMediator<float> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(NullableFloatFieldExpression a, ExpressionMediator<float> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(NullableFloatFieldExpression a, ExpressionMediator<float> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(NullableFloatFieldExpression a, ExpressionMediator<float> b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(ExpressionMediator<float> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(ExpressionMediator<float> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(ExpressionMediator<float> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(ExpressionMediator<float> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(ExpressionMediator<float> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(ExpressionMediator<float> a, NullableFloatFieldExpression b) => new FilterExpression<float?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
