using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class DoubleFieldExpression : FieldExpression<double>,
        ISupportedForSelectFieldExpression<double>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, double>,
        ISupportedForFunctionExpression<CastFunctionExpression, double>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, double>,
        ISupportedForFunctionExpression<CountFunctionExpression, double>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, double>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, double>,
        ISupportedForFunctionExpression<AverageFunctionExpression, double>,
        ISupportedForFunctionExpression<SumFunctionExpression, double>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, double>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, double>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, double>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, double>
    {
        public DoubleFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, double>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected DoubleFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, double>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region double
        public static ExpressionMediator<double> operator +(DoubleFieldExpression a, double b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<double> operator -(DoubleFieldExpression a, double b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<double> operator *(DoubleFieldExpression a, double b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<double> operator /(DoubleFieldExpression a, double b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<double> operator %(DoubleFieldExpression a, double b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<double> operator +(double a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<double> operator -(double a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<double> operator *(double a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<double> operator /(double a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<double> operator %(double a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<double> operator +(DoubleFieldExpression a, double? b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<double> operator -(DoubleFieldExpression a, double? b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<double> operator *(DoubleFieldExpression a, double? b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<double> operator /(DoubleFieldExpression a, double? b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<double> operator %(DoubleFieldExpression a, double? b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<double> operator +(double? a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<double> operator -(double? a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<double> operator *(double? a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<double> operator /(double? a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<double> operator %(double? a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region mediator
        public static ExpressionMediator<double> operator +(DoubleFieldExpression a, ExpressionMediator<double> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<double> operator -(DoubleFieldExpression a, ExpressionMediator<double> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<double> operator *(DoubleFieldExpression a, ExpressionMediator<double> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<double> operator /(DoubleFieldExpression a, ExpressionMediator<double> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<double> operator %(DoubleFieldExpression a, ExpressionMediator<double> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(DoubleFieldExpression a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(DoubleFieldExpression a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(DoubleFieldExpression a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(DoubleFieldExpression a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(DoubleFieldExpression a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region double
        public static FilterExpression<double> operator ==(DoubleFieldExpression field, double? value) => new FilterExpression<double>(field, new LiteralExpression<double?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<double> operator !=(DoubleFieldExpression field, double? value) => new FilterExpression<double>(field, new LiteralExpression<double?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<double> operator <(DoubleFieldExpression field, double? value) => new FilterExpression<double>(field, new LiteralExpression<double?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<double> operator <=(DoubleFieldExpression field, double? value) => new FilterExpression<double>(field, new LiteralExpression<double?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<double> operator >(DoubleFieldExpression field, double? value) => new FilterExpression<double>(field, new LiteralExpression<double?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<double> operator >=(DoubleFieldExpression field, double? value) => new FilterExpression<double>(field, new LiteralExpression<double?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<double> operator ==(double? value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<double> operator !=(double? value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<double> operator <(double? value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<double> operator <=(double? value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<double> operator >(double? value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<double> operator >=(double? value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<double> operator ==(DoubleFieldExpression field, double value) => new FilterExpression<double>(field, new LiteralExpression<double>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<double> operator !=(DoubleFieldExpression field, double value) => new FilterExpression<double>(field, new LiteralExpression<double>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<double> operator <(DoubleFieldExpression field, double value) => new FilterExpression<double>(field, new LiteralExpression<double>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<double> operator <=(DoubleFieldExpression field, double value) => new FilterExpression<double>(field, new LiteralExpression<double>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<double> operator >(DoubleFieldExpression field, double value) => new FilterExpression<double>(field, new LiteralExpression<double>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<double> operator >=(DoubleFieldExpression field, double value) => new FilterExpression<double>(field, new LiteralExpression<double>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<double> operator ==(double value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<double> operator !=(double value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<double> operator <(double value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<double> operator <=(double value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<double> operator >(double value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<double> operator >=(double value, DoubleFieldExpression field) => new FilterExpression<double>(new LiteralExpression<double>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<double?> operator ==(DoubleFieldExpression a, DoubleFieldExpression b) => new FilterExpression<double?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<double?> operator !=(DoubleFieldExpression a, DoubleFieldExpression b) => new FilterExpression<double?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<double?> operator <(DoubleFieldExpression a, DoubleFieldExpression b) => new FilterExpression<double?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<double?> operator <=(DoubleFieldExpression a, DoubleFieldExpression b) => new FilterExpression<double?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<double?> operator >(DoubleFieldExpression a, DoubleFieldExpression b) => new FilterExpression<double?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<double?> operator >=(DoubleFieldExpression a, DoubleFieldExpression b) => new FilterExpression<double?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<double> operator ==(DoubleFieldExpression a, ExpressionMediator<double> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<double> operator !=(DoubleFieldExpression a, ExpressionMediator<double> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<double> operator <(DoubleFieldExpression a, ExpressionMediator<double> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<double> operator <=(DoubleFieldExpression a, ExpressionMediator<double> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<double> operator >(DoubleFieldExpression a, ExpressionMediator<double> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<double> operator >=(DoubleFieldExpression a, ExpressionMediator<double> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<double> operator ==(ExpressionMediator<double> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<double> operator !=(ExpressionMediator<double> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<double> operator <(ExpressionMediator<double> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<double> operator <=(ExpressionMediator<double> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<double> operator >(ExpressionMediator<double> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<double> operator >=(ExpressionMediator<double> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<double> operator ==(DoubleFieldExpression a, ExpressionMediator<double?> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<double> operator !=(DoubleFieldExpression a, ExpressionMediator<double?> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<double> operator <(DoubleFieldExpression a, ExpressionMediator<double?> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<double> operator <=(DoubleFieldExpression a, ExpressionMediator<double?> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<double> operator >(DoubleFieldExpression a, ExpressionMediator<double?> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<double> operator >=(DoubleFieldExpression a, ExpressionMediator<double?> b) => new FilterExpression<double>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<double> operator ==(ExpressionMediator<double?> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<double> operator !=(ExpressionMediator<double?> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<double> operator <(ExpressionMediator<double?> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<double> operator <=(ExpressionMediator<double?> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<double> operator >(ExpressionMediator<double?> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<double> operator >=(ExpressionMediator<double?> a, DoubleFieldExpression b) => new FilterExpression<double>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
