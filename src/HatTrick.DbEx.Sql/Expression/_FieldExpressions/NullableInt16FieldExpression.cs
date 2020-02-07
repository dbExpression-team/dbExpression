using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableInt16FieldExpression : NullableFieldExpression<short>,
        ISupportedForSelectFieldExpression<short?>,
        ISupportedForFunctionExpression<CastFunctionExpression, short?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, short?>,
        ISupportedForFunctionExpression<NullableCastFunctionExpression, short?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>,
        ISupportedForFunctionExpression<CountFunctionExpression, short?>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, short?>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, short?>,
        ISupportedForFunctionExpression<AverageFunctionExpression, short?>,
        ISupportedForFunctionExpression<SumFunctionExpression, short?>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, short?>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, short?>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, short?>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, short?>
    {
        protected NullableInt16FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, short?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableInt16FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, short?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region short
        public static NullableExpressionMediator<short?> operator +(NullableInt16FieldExpression a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableInt16FieldExpression a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableInt16FieldExpression a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableInt16FieldExpression a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableInt16FieldExpression a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(short? a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(short? a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(short? a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(short? a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(short? a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(NullableInt16FieldExpression a, short b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableInt16FieldExpression a, short b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableInt16FieldExpression a, short b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableInt16FieldExpression a, short b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableInt16FieldExpression a, short b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(short a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(short a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(short a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(short a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(short a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region mediator
        public static NullableExpressionMediator<short?> operator +(NullableInt16FieldExpression a, ExpressionMediator<short> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableInt16FieldExpression a, ExpressionMediator<short> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableInt16FieldExpression a, ExpressionMediator<short> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableInt16FieldExpression a, ExpressionMediator<short> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableInt16FieldExpression a, ExpressionMediator<short> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(NullableInt16FieldExpression a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableInt16FieldExpression a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableInt16FieldExpression a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableInt16FieldExpression a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableInt16FieldExpression a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<short?> operator ==(NullableInt16FieldExpression field, DBNull value) => new FilterExpression<short?>(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(NullableInt16FieldExpression field, DBNull value) => new FilterExpression<short?>(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator ==(DBNull value, NullableInt16FieldExpression field) => new FilterExpression<short?>(value, field, FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(DBNull value, NullableInt16FieldExpression field) => new FilterExpression<short?>(value, field, FilterExpressionOperator.NotEqual);
        #endregion

        #region short
        public static FilterExpression<short?> operator ==(NullableInt16FieldExpression field, short? value) => new FilterExpression<short?>(field, new LiteralExpression<short?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(NullableInt16FieldExpression field, short? value) => new FilterExpression<short?>(field, new LiteralExpression<short?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator <(NullableInt16FieldExpression field, short? value) => new FilterExpression<short?>(field, new LiteralExpression<short?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<short?> operator <=(NullableInt16FieldExpression field, short? value) => new FilterExpression<short?>(field, new LiteralExpression<short?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<short?> operator >(NullableInt16FieldExpression field, short? value) => new FilterExpression<short?>(field, new LiteralExpression<short?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<short?> operator >=(NullableInt16FieldExpression field, short? value) => new FilterExpression<short?>(field, new LiteralExpression<short?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<short?> operator ==(short? value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(short? value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator <(short? value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<short?> operator <=(short? value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<short?> operator >(short? value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<short?> operator >=(short? value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<short?> operator ==(NullableInt16FieldExpression field, short value) => new FilterExpression<short?>(field, new LiteralExpression<short>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(NullableInt16FieldExpression field, short value) => new FilterExpression<short?>(field, new LiteralExpression<short>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator <(NullableInt16FieldExpression field, short value) => new FilterExpression<short?>(field, new LiteralExpression<short>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<short?> operator <=(NullableInt16FieldExpression field, short value) => new FilterExpression<short?>(field, new LiteralExpression<short>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<short?> operator >(NullableInt16FieldExpression field, short value) => new FilterExpression<short?>(field, new LiteralExpression<short>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<short?> operator >=(NullableInt16FieldExpression field, short value) => new FilterExpression<short?>(field, new LiteralExpression<short>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<short?> operator ==(short value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(short value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator <(short value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<short?> operator <=(short value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<short?> operator >(short value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<short?> operator >=(short value, NullableInt16FieldExpression field) => new FilterExpression<short?>(new LiteralExpression<short>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<short?> operator ==(NullableInt16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(NullableInt16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator <(NullableInt16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<short?> operator <=(NullableInt16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<short?> operator >(NullableInt16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<short?> operator >=(NullableInt16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<short?> operator ==(NullableInt16FieldExpression a, Int16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(NullableInt16FieldExpression a, Int16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator <(NullableInt16FieldExpression a, Int16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<short?> operator <=(NullableInt16FieldExpression a, Int16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<short?> operator >(NullableInt16FieldExpression a, Int16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<short?> operator >=(NullableInt16FieldExpression a, Int16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<short?> operator ==(Int16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(Int16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator <(Int16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<short?> operator <=(Int16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<short?> operator >(Int16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<short?> operator >=(Int16FieldExpression a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<short?> operator ==(NullableInt16FieldExpression a, ExpressionMediator<short?> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(NullableInt16FieldExpression a, ExpressionMediator<short?> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator <(NullableInt16FieldExpression a, ExpressionMediator<short?> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<short?> operator <=(NullableInt16FieldExpression a, ExpressionMediator<short?> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<short?> operator >(NullableInt16FieldExpression a, ExpressionMediator<short?> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<short?> operator >=(NullableInt16FieldExpression a, ExpressionMediator<short?> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<short?> operator ==(ExpressionMediator<short?> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(ExpressionMediator<short?> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator <(ExpressionMediator<short?> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<short?> operator <=(ExpressionMediator<short?> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<short?> operator >(ExpressionMediator<short?> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<short?> operator >=(ExpressionMediator<short?> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<short?> operator ==(NullableInt16FieldExpression a, ExpressionMediator<short> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(NullableInt16FieldExpression a, ExpressionMediator<short> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator <(NullableInt16FieldExpression a, ExpressionMediator<short> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<short?> operator <=(NullableInt16FieldExpression a, ExpressionMediator<short> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<short?> operator >(NullableInt16FieldExpression a, ExpressionMediator<short> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<short?> operator >=(NullableInt16FieldExpression a, ExpressionMediator<short> b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<short?> operator ==(ExpressionMediator<short> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<short?> operator !=(ExpressionMediator<short> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<short?> operator <(ExpressionMediator<short> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<short?> operator <=(ExpressionMediator<short> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<short?> operator >(ExpressionMediator<short> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<short?> operator >=(ExpressionMediator<short> a, NullableInt16FieldExpression b) => new FilterExpression<short?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
