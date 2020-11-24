using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator BooleanExpressionMediator(BooleanCastFunctionExpression a) => new BooleanExpressionMediator(a);
        public static implicit operator OrderByExpression(BooleanCastFunctionExpression a) => new OrderByExpression(new BooleanExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(BooleanCastFunctionExpression a) => new GroupByExpression(new BooleanExpressionMediator(a));
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
        
        #region string

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region bool
        public static FilterExpressionSet operator ==(BooleanCastFunctionExpression a, bool b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(BooleanCastFunctionExpression a, bool b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(BooleanCastFunctionExpression a, bool b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(BooleanCastFunctionExpression a, bool b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(BooleanCastFunctionExpression a, bool b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(BooleanCastFunctionExpression a, bool b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(bool a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(bool a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(bool a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(bool a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(bool a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(bool a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(BooleanCastFunctionExpression a, bool? b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(BooleanCastFunctionExpression a, bool? b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(BooleanCastFunctionExpression a, bool? b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(BooleanCastFunctionExpression a, bool? b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(BooleanCastFunctionExpression a, bool? b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(BooleanCastFunctionExpression a, bool? b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(bool? a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(bool? a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(bool? a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(bool? a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(bool? a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(bool? a, BooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(BooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(BooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(BooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(BooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(BooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(BooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(BooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(BooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(BooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(BooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(BooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(BooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
