using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class Int32FieldExpression : FieldExpression<int>,
        ISupportedForSelectFieldExpression<int>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, int>,
        ISupportedForFunctionExpression<CastFunctionExpression, int>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, int>,
        ISupportedForFunctionExpression<CountFunctionExpression, int>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, int>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, int>,
        ISupportedForFunctionExpression<AverageFunctionExpression, int>,
        ISupportedForFunctionExpression<SumFunctionExpression, int>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, int>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, int>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, int>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, int>
    {
        protected Int32FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, int>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected Int32FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, int>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region int
        public static ExpressionMediator<int> operator +(Int32FieldExpression a, int b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<int> operator -(Int32FieldExpression a, int b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<int> operator *(Int32FieldExpression a, int b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<int> operator /(Int32FieldExpression a, int b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<int> operator %(Int32FieldExpression a, int b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<int> operator +(int a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<int> operator -(int a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<int> operator *(int a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<int> operator /(int a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<int> operator %(int a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<int> operator +(Int32FieldExpression a, int? b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<int> operator -(Int32FieldExpression a, int? b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<int> operator *(Int32FieldExpression a, int? b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<int> operator /(Int32FieldExpression a, int? b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<int> operator %(Int32FieldExpression a, int? b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<int> operator +(int? a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<int> operator -(int? a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<int> operator *(int? a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<int> operator /(int? a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<int> operator %(int? a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region mediator
        public static ExpressionMediator<int> operator +(Int32FieldExpression a, ExpressionMediator<int> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<int> operator -(Int32FieldExpression a, ExpressionMediator<int> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<int> operator *(Int32FieldExpression a, ExpressionMediator<int> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<int> operator /(Int32FieldExpression a, ExpressionMediator<int> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<int> operator %(Int32FieldExpression a, ExpressionMediator<int> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(Int32FieldExpression a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(Int32FieldExpression a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(Int32FieldExpression a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(Int32FieldExpression a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(Int32FieldExpression a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region int
        public static FilterExpression<int> operator ==(Int32FieldExpression field, int? value) => new FilterExpression<int>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(Int32FieldExpression field, int? value) => new FilterExpression<int>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(Int32FieldExpression field, int? value) => new FilterExpression<int>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(Int32FieldExpression field, int? value) => new FilterExpression<int>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(Int32FieldExpression field, int? value) => new FilterExpression<int>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(Int32FieldExpression field, int? value) => new FilterExpression<int>(field, new LiteralExpression<int?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int> operator ==(int? value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(int? value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(int? value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(int? value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(int? value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(int? value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int> operator ==(Int32FieldExpression field, int value) => new FilterExpression<int>(field, new LiteralExpression<int>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(Int32FieldExpression field, int value) => new FilterExpression<int>(field, new LiteralExpression<int>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(Int32FieldExpression field, int value) => new FilterExpression<int>(field, new LiteralExpression<int>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(Int32FieldExpression field, int value) => new FilterExpression<int>(field, new LiteralExpression<int>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(Int32FieldExpression field, int value) => new FilterExpression<int>(field, new LiteralExpression<int>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(Int32FieldExpression field, int value) => new FilterExpression<int>(field, new LiteralExpression<int>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int> operator ==(int value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(int value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(int value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(int value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(int value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(int value, Int32FieldExpression field) => new FilterExpression<int>(new LiteralExpression<int>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<int?> operator ==(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(Int32FieldExpression a, Int32FieldExpression b) => new FilterExpression<int?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<int> operator ==(Int32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(Int32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(Int32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(Int32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(Int32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(Int32FieldExpression a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int> operator ==(ExpressionMediator<int> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(ExpressionMediator<int> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(ExpressionMediator<int> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(ExpressionMediator<int> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(ExpressionMediator<int> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(ExpressionMediator<int> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int> operator ==(Int32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(Int32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(Int32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(Int32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(Int32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(Int32FieldExpression a, ExpressionMediator<int?> b) => new FilterExpression<int>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int> operator ==(ExpressionMediator<int?> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(ExpressionMediator<int?> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(ExpressionMediator<int?> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(ExpressionMediator<int?> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(ExpressionMediator<int?> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(ExpressionMediator<int?> a, Int32FieldExpression b) => new FilterExpression<int>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}

