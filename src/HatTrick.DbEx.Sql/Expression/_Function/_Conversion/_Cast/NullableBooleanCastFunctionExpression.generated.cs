using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableBooleanExpressionMediator(NullableBooleanCastFunctionExpression a) => new NullableBooleanExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableBooleanCastFunctionExpression a) => new OrderByExpression(new BooleanExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableBooleanCastFunctionExpression a) => new GroupByExpression(new BooleanExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new BooleanExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new BooleanExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region bool



        
        #endregion
        
        #region byte



        
        #endregion
        
        #region decimal



        
        #endregion
        
        #region DateTime



        
        #endregion
        
        #region DateTimeOffset



        
        #endregion
        
        #region double



        
        #endregion
        
        #region float



        
        #endregion
        
        #region Guid



        
        #endregion
        
        #region short



        
        #endregion
        
        #region int



        
        #endregion
        
        #region long



        
        #endregion
        
        #region string
        
        #endregion
        
        #region TimeSpan



        
        #endregion
        
        #endregion

        #region mediator
        #region bool

        #endregion
        
        #region byte

        #endregion
        
        #region decimal

        #endregion
        
        #region DateTime

        #endregion
        
        #region DateTimeOffset

        #endregion
        
        #region double

        #endregion
        
        #region float

        #endregion
        
        #region Guid

        #endregion
        
        #region short

        #endregion
        
        #region int

        #endregion
        
        #region long

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region bool
        public static FilterExpression<bool?> operator ==(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new NullableBooleanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool?> operator ==(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
