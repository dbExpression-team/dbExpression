using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableCastFunctionExpression<TValue> : NullableCastFunctionExpression,
        IDbFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForFunctionExpression<AverageFunctionExpression, TValue>,
        ISupportedForFunctionExpression<CastFunctionExpression, TValue>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, TValue>,
        ISupportedForFunctionExpression<ConcatFunctionExpression, TValue>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, TValue>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, TValue>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, TValue>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, TValue>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, TValue>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, TValue>,
        ISupportedForFunctionExpression<SumFunctionExpression, TValue>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, TValue>,
        ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<TValue>, TValue>,
        ISupportedForSelectFieldExpression<TValue>,
        IEquatable<NullableCastFunctionExpression<TValue>>
    {
        #region constructors
        internal NullableCastFunctionExpression()
        {
        }

        public NullableCastFunctionExpression((Type, object) expression) : base(expression)
        {
        }

        #endregion

        #region as
        public new NullableCastFunctionExpression<TValue> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableCastFunctionExpression<TValue> obj)
            => obj is NullableCastFunctionExpression<TValue> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableCastFunctionExpression<TValue> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        //MILESTONE: Function Arithmetic
        //public static implicit operator NullableExpressionMediator<TValue>(NullableCastFunctionExpression<TValue> cast) => new NullableExpressionMediator<TValue>((cast.GetType(), cast));
        public static implicit operator OrderByExpression(NullableCastFunctionExpression<TValue> cast) => new OrderByExpression((cast.GetType(), cast), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableCastFunctionExpression<TValue> cast) => new GroupByExpression((cast.GetType(), cast));
        #endregion

        #region filter operators
        #region TValue
        public static FilterExpression<TValue> operator ==(NullableCastFunctionExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<TValue> operator !=(NullableCastFunctionExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TValue> operator <(NullableCastFunctionExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<TValue> operator <=(NullableCastFunctionExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TValue> operator >(NullableCastFunctionExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TValue> operator >=(NullableCastFunctionExpression<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<TValue> operator ==(TValue a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<TValue> operator !=(TValue a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TValue> operator <(TValue a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<TValue> operator <=(TValue a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TValue> operator >(TValue a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TValue> operator >=(TValue a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        //no implicit operators needed as the "general" implicit from Cast.. to ExpressionMediator.. handles all mediator conversions
        //public static FilterExpression<TValue> operator ==(NullableCastFunctionExpression<TValue> a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.Equal);

        //public static FilterExpression<TValue> operator !=(NullableCastFunctionExpression<TValue> a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.NotEqual);

        //public static FilterExpression<TValue> operator <(NullableCastFunctionExpression<TValue> a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.LessThan);

        //public static FilterExpression<TValue> operator <=(NullableCastFunctionExpression<TValue> a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        //public static FilterExpression<TValue> operator >(NullableCastFunctionExpression<TValue> a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        //public static FilterExpression<TValue> operator >=(NullableCastFunctionExpression<TValue> a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        //public static FilterExpression<TValue> operator ==(ExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.Equal);

        //public static FilterExpression<TValue> operator !=(ExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.NotEqual);

        //public static FilterExpression<TValue> operator <(ExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.LessThan);

        //public static FilterExpression<TValue> operator <=(ExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        //public static FilterExpression<TValue> operator >(ExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        //public static FilterExpression<TValue> operator >=(ExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);

        //public static FilterExpression<TValue> operator ==(NullableCastFunctionExpression<TValue> a, NullableExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.Equal);

        //public static FilterExpression<TValue> operator !=(NullableCastFunctionExpression<TValue> a, NullableExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.NotEqual);

        //public static FilterExpression<TValue> operator <(NullableCastFunctionExpression<TValue> a, NullableExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.LessThan);

        //public static FilterExpression<TValue> operator <=(NullableCastFunctionExpression<TValue> a, NullableExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        //public static FilterExpression<TValue> operator >(NullableCastFunctionExpression<TValue> a, NullableExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        //public static FilterExpression<TValue> operator >=(NullableCastFunctionExpression<TValue> a, NullableExpressionMediator<TValue> b) => new FilterExpression<TValue>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        //public static FilterExpression<TValue> operator ==(NullableExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.Equal);

        //public static FilterExpression<TValue> operator !=(NullableExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.NotEqual);

        //public static FilterExpression<TValue> operator <(NullableExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.LessThan);

        //public static FilterExpression<TValue> operator <=(NullableExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        //public static FilterExpression<TValue> operator >(NullableExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        //public static FilterExpression<TValue> operator >=(NullableExpressionMediator<TValue> a, NullableCastFunctionExpression<TValue> b) => new FilterExpression<TValue>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
