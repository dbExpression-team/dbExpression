using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableInt32FieldExpression : NullableFieldExpression<int>,
        ISupportedForSelectFieldExpression<int?>,
        ISupportedForFunctionExpression<CastFunctionExpression, int?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, int?>,
        ISupportedForFunctionExpression<NullableCastFunctionExpression, int?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>,
        ISupportedForFunctionExpression<CountFunctionExpression, int?>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, int?>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, int?>,
        ISupportedForFunctionExpression<AverageFunctionExpression, int?>,
        ISupportedForFunctionExpression<SumFunctionExpression, int?>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, int?>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, int?>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, int?>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, int?>
    {
        protected NullableInt32FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, int?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableInt32FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, int?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region int
        public static NullableExpressionMediator<int?> operator +(NullableInt32FieldExpression a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableInt32FieldExpression a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableInt32FieldExpression a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableInt32FieldExpression a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableInt32FieldExpression a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(int? a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(int? a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(int? a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(int? a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(int? a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(NullableInt32FieldExpression a, int b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableInt32FieldExpression a, int b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableInt32FieldExpression a, int b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableInt32FieldExpression a, int b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableInt32FieldExpression a, int b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(int a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(int a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(int a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(int a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(int a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region mediator
        public static NullableExpressionMediator<int?> operator +(NullableInt32FieldExpression a, ExpressionMediator<int> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableInt32FieldExpression a, ExpressionMediator<int> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableInt32FieldExpression a, ExpressionMediator<int> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableInt32FieldExpression a, ExpressionMediator<int> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableInt32FieldExpression a, ExpressionMediator<int> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(NullableInt32FieldExpression a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableInt32FieldExpression a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableInt32FieldExpression a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableInt32FieldExpression a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableInt32FieldExpression a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<int?> operator ==(NullableInt32FieldExpression field, DBNull value) => new FilterExpression<int?>(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(NullableInt32FieldExpression field, DBNull value) => new FilterExpression<int?>(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator ==(DBNull value, NullableInt32FieldExpression field) => new FilterExpression<int?>(value, field, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(DBNull value, NullableInt32FieldExpression field) => new FilterExpression<int?>(value, field, FilterExpressionOperator.NotEqual);
        #endregion

        #region int
        public static FilterExpression<int?> operator ==(NullableInt32FieldExpression field, int? value) => new FilterExpression<int?>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(NullableInt32FieldExpression field, int? value) => new FilterExpression<int?>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(NullableInt32FieldExpression field, int? value) => new FilterExpression<int?>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(NullableInt32FieldExpression field, int? value) => new FilterExpression<int?>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(NullableInt32FieldExpression field, int? value) => new FilterExpression<int?>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(NullableInt32FieldExpression field, int? value) => new FilterExpression<int?>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(int? value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(int? value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(int? value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(int? value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(int? value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(int? value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(NullableInt32FieldExpression field, int value) => new FilterExpression<int?>(field, new LiteralExpression<int>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(NullableInt32FieldExpression field, int value) => new FilterExpression<int?>(field, new LiteralExpression<int>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(NullableInt32FieldExpression field, int value) => new FilterExpression<int?>(field, new LiteralExpression<int>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(NullableInt32FieldExpression field, int value) => new FilterExpression<int?>(field, new LiteralExpression<int>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(NullableInt32FieldExpression field, int value) => new FilterExpression<int?>(field, new LiteralExpression<int>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(NullableInt32FieldExpression field, int value) => new FilterExpression<int?>(field, new LiteralExpression<int>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(int value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(int value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(int value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(int value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(int value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(int value, NullableInt32FieldExpression field) => new FilterExpression<int?>(new LiteralExpression<int>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<int?> operator ==(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(NullableInt32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(NullableInt32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(NullableInt32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(NullableInt32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(NullableInt32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(NullableInt32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(NullableInt32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(Int32FieldExpression a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<int?> operator ==(NullableInt32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(NullableInt32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(NullableInt32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(NullableInt32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(NullableInt32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(NullableInt32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(ExpressionMediator<int?> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(ExpressionMediator<int?> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(ExpressionMediator<int?> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(ExpressionMediator<int?> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(ExpressionMediator<int?> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(ExpressionMediator<int?> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(NullableInt32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(NullableInt32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(NullableInt32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(NullableInt32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(NullableInt32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(NullableInt32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(ExpressionMediator<int> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(ExpressionMediator<int> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(ExpressionMediator<int> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(ExpressionMediator<int> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(ExpressionMediator<int> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(ExpressionMediator<int> a, NullableInt32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
