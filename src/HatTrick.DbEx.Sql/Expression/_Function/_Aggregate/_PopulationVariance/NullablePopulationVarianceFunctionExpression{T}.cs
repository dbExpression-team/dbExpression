using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class NullablePopulationVarianceFunctionExpression<TValue> : NullablePopulationVarianceFunctionExpression,
        IDbFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForFunctionExpression<CastFunctionExpression, float?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>,
        ISupportedForFunctionExpression<ConcatFunctionExpression, float?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, float?>,
        ISupportedForSelectFieldExpression<TValue>,
        IEquatable<NullablePopulationVarianceFunctionExpression<TValue>>
    {
        #region constructors
        internal NullablePopulationVarianceFunctionExpression()
        {
        }

        public NullablePopulationVarianceFunctionExpression((Type, object) expression, bool isDistinct) : base(expression, isDistinct)
        {
        }

        #endregion

        #region as
        public new NullablePopulationVarianceFunctionExpression<TValue> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullablePopulationVarianceFunctionExpression<TValue> obj)
            => obj is NullablePopulationVarianceFunctionExpression<TValue> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullablePopulationVarianceFunctionExpression<TValue> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        //MILESTONE: Function Arithmetic
        //public static implicit operator NullableExpressionMediator<TValue>(NullablePopulationVarianceFunctionExpression<TValue> varp) => new NullableExpressionMediator<TValue>((varp.GetType(), varp));
        public static implicit operator OrderByExpression(NullablePopulationVarianceFunctionExpression<TValue> varp) => new OrderByExpression((varp.GetType(), varp), OrderExpressionDirection.ASC);
        #endregion

        #region filter operators
        #region TValue
        #region float
        public static FilterExpression<float> operator ==(NullablePopulationVarianceFunctionExpression<TValue> a, float b) => new FilterExpression<float>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<float> operator !=(NullablePopulationVarianceFunctionExpression<TValue> a, float b) => new FilterExpression<float>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<float> operator <(NullablePopulationVarianceFunctionExpression<TValue> a, float b) => new FilterExpression<float>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<float> operator <=(NullablePopulationVarianceFunctionExpression<TValue> a, float b) => new FilterExpression<float>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float> operator >(NullablePopulationVarianceFunctionExpression<TValue> a, float b) => new FilterExpression<float>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float> operator >=(NullablePopulationVarianceFunctionExpression<TValue> a, float b) => new FilterExpression<float>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float> operator ==(float a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<float> operator !=(float a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float> operator <(float a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<float> operator <=(float a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float> operator >(float a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float> operator >=(float a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(NullablePopulationVarianceFunctionExpression<TValue> a, float? b) => new FilterExpression<float?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(NullablePopulationVarianceFunctionExpression<TValue> a, float? b) => new FilterExpression<float?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(NullablePopulationVarianceFunctionExpression<TValue> a, float? b) => new FilterExpression<float?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(NullablePopulationVarianceFunctionExpression<TValue> a, float? b) => new FilterExpression<float?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(NullablePopulationVarianceFunctionExpression<TValue> a, float? b) => new FilterExpression<float?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(NullablePopulationVarianceFunctionExpression<TValue> a, float? b) => new FilterExpression<float?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(float? a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(float? a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(float? a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(float? a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(float? a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(float? a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        #region float
        public static FilterExpression<float> operator ==(NullablePopulationVarianceFunctionExpression<TValue> a, ExpressionMediator<float> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<float> operator !=(NullablePopulationVarianceFunctionExpression<TValue> a, ExpressionMediator<float> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float> operator <(NullablePopulationVarianceFunctionExpression<TValue> a, ExpressionMediator<float> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<float> operator <=(NullablePopulationVarianceFunctionExpression<TValue> a, ExpressionMediator<float> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float> operator >(NullablePopulationVarianceFunctionExpression<TValue> a, ExpressionMediator<float> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float> operator >=(NullablePopulationVarianceFunctionExpression<TValue> a, ExpressionMediator<float> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float> operator ==(ExpressionMediator<float> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<float> operator !=(ExpressionMediator<float> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float> operator <(ExpressionMediator<float> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<float> operator <=(ExpressionMediator<float> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float> operator >(ExpressionMediator<float> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float> operator >=(ExpressionMediator<float> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(NullablePopulationVarianceFunctionExpression<TValue> a, NullableExpressionMediator<float?> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(NullablePopulationVarianceFunctionExpression<TValue> a, NullableExpressionMediator<float?> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(NullablePopulationVarianceFunctionExpression<TValue> a, NullableExpressionMediator<float?> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(NullablePopulationVarianceFunctionExpression<TValue> a, NullableExpressionMediator<float?> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(NullablePopulationVarianceFunctionExpression<TValue> a, NullableExpressionMediator<float?> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(NullablePopulationVarianceFunctionExpression<TValue> a, NullableExpressionMediator<float?> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<float?> operator ==(NullableExpressionMediator<float?> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<float?> operator !=(NullableExpressionMediator<float?> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<float?> operator <(NullableExpressionMediator<float?> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<float?> operator <=(NullableExpressionMediator<float?> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<float?> operator >(NullableExpressionMediator<float?> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<float?> operator >=(NullableExpressionMediator<float?> a, NullablePopulationVarianceFunctionExpression<TValue> b) => new FilterExpression<float?>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
        #endregion
    }
}
