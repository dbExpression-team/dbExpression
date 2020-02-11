using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableDecimalFieldExpression : NullableFieldExpression<decimal>,
        ISupportedForSelectFieldExpression<decimal?>,
        ISupportedForFunctionExpression<CastFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<NullableCastFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<CountFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<AverageFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<SumFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, decimal?>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, decimal?>
    {
        protected NullableDecimalFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, decimal?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableDecimalFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, decimal?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region decimal
        public static NullableExpressionMediator<decimal?> operator +(NullableDecimalFieldExpression a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableDecimalFieldExpression a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableDecimalFieldExpression a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableDecimalFieldExpression a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableDecimalFieldExpression a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(decimal? a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(decimal? a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(decimal? a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(decimal? a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(decimal? a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(NullableDecimalFieldExpression a, decimal b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableDecimalFieldExpression a, decimal b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableDecimalFieldExpression a, decimal b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableDecimalFieldExpression a, decimal b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableDecimalFieldExpression a, decimal b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(decimal a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(decimal a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(decimal a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(decimal a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(decimal a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region mediator
        public static NullableExpressionMediator<decimal?> operator +(NullableDecimalFieldExpression a, ExpressionMediator<decimal> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableDecimalFieldExpression a, ExpressionMediator<decimal> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableDecimalFieldExpression a, ExpressionMediator<decimal> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableDecimalFieldExpression a, ExpressionMediator<decimal> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableDecimalFieldExpression a, ExpressionMediator<decimal> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(NullableDecimalFieldExpression a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableDecimalFieldExpression a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableDecimalFieldExpression a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableDecimalFieldExpression a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableDecimalFieldExpression a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<decimal?> operator ==(NullableDecimalFieldExpression field, DBNull value) => new FilterExpression<decimal?>(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(NullableDecimalFieldExpression field, DBNull value) => new FilterExpression<decimal?>(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator ==(DBNull value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(value, field, FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(DBNull value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(value, field, FilterExpressionOperator.NotEqual);
        #endregion

        #region decimal
        public static FilterExpression<decimal?> operator ==(NullableDecimalFieldExpression field, decimal? value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(NullableDecimalFieldExpression field, decimal? value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator <(NullableDecimalFieldExpression field, decimal? value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<decimal?> operator <=(NullableDecimalFieldExpression field, decimal? value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<decimal?> operator >(NullableDecimalFieldExpression field, decimal? value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<decimal?> operator >=(NullableDecimalFieldExpression field, decimal? value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<decimal?> operator ==(decimal? value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(decimal? value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator <(decimal? value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<decimal?> operator <=(decimal? value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<decimal?> operator >(decimal? value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<decimal?> operator >=(decimal? value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<decimal?> operator ==(NullableDecimalFieldExpression field, decimal value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(NullableDecimalFieldExpression field, decimal value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator <(NullableDecimalFieldExpression field, decimal value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<decimal?> operator <=(NullableDecimalFieldExpression field, decimal value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<decimal?> operator >(NullableDecimalFieldExpression field, decimal value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<decimal?> operator >=(NullableDecimalFieldExpression field, decimal value) => new FilterExpression<decimal?>(field, new LiteralExpression<decimal>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<decimal?> operator ==(decimal value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(decimal value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator <(decimal value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<decimal?> operator <=(decimal value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<decimal?> operator >(decimal value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<decimal?> operator >=(decimal value, NullableDecimalFieldExpression field) => new FilterExpression<decimal?>(new LiteralExpression<decimal>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<decimal?> operator ==(NullableDecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(NullableDecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator <(NullableDecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<decimal?> operator <=(NullableDecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<decimal?> operator >(NullableDecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<decimal?> operator >=(NullableDecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<decimal?> operator ==(NullableDecimalFieldExpression a, DecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(NullableDecimalFieldExpression a, DecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator <(NullableDecimalFieldExpression a, DecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<decimal?> operator <=(NullableDecimalFieldExpression a, DecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<decimal?> operator >(NullableDecimalFieldExpression a, DecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<decimal?> operator >=(NullableDecimalFieldExpression a, DecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<decimal?> operator ==(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator <(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<decimal?> operator <=(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<decimal?> operator >(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<decimal?> operator >=(DecimalFieldExpression a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<decimal?> operator ==(NullableDecimalFieldExpression a, ExpressionMediator<decimal?> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(NullableDecimalFieldExpression a, ExpressionMediator<decimal?> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator <(NullableDecimalFieldExpression a, ExpressionMediator<decimal?> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<decimal?> operator <=(NullableDecimalFieldExpression a, ExpressionMediator<decimal?> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<decimal?> operator >(NullableDecimalFieldExpression a, ExpressionMediator<decimal?> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<decimal?> operator >=(NullableDecimalFieldExpression a, ExpressionMediator<decimal?> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<decimal?> operator ==(ExpressionMediator<decimal?> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(ExpressionMediator<decimal?> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator <(ExpressionMediator<decimal?> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<decimal?> operator <=(ExpressionMediator<decimal?> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<decimal?> operator >(ExpressionMediator<decimal?> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<decimal?> operator >=(ExpressionMediator<decimal?> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<decimal?> operator ==(NullableDecimalFieldExpression a, ExpressionMediator<decimal> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(NullableDecimalFieldExpression a, ExpressionMediator<decimal> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator <(NullableDecimalFieldExpression a, ExpressionMediator<decimal> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<decimal?> operator <=(NullableDecimalFieldExpression a, ExpressionMediator<decimal> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<decimal?> operator >(NullableDecimalFieldExpression a, ExpressionMediator<decimal> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<decimal?> operator >=(NullableDecimalFieldExpression a, ExpressionMediator<decimal> b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<decimal?> operator ==(ExpressionMediator<decimal> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<decimal?> operator !=(ExpressionMediator<decimal> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<decimal?> operator <(ExpressionMediator<decimal> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<decimal?> operator <=(ExpressionMediator<decimal> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<decimal?> operator >(ExpressionMediator<decimal> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<decimal?> operator >=(ExpressionMediator<decimal> a, NullableDecimalFieldExpression b) => new FilterExpression<decimal?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
