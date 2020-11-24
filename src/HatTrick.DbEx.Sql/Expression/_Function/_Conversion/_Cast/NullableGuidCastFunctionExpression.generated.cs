using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableGuidExpressionMediator(NullableGuidCastFunctionExpression a) => new NullableGuidExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableGuidCastFunctionExpression a) => new OrderByExpression(new GuidExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableGuidCastFunctionExpression a) => new GroupByExpression(new GuidExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new GuidExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new GuidExpressionMediator(this), OrderExpressionDirection.DESC);
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
        #region Guid
        public static FilterExpressionSet operator ==(NullableGuidCastFunctionExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidCastFunctionExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableGuidCastFunctionExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableGuidCastFunctionExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableGuidCastFunctionExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableGuidCastFunctionExpression a, Guid b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(Guid a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Guid a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(Guid a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(Guid a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(Guid a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableGuidCastFunctionExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidCastFunctionExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableGuidCastFunctionExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableGuidCastFunctionExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableGuidCastFunctionExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableGuidCastFunctionExpression a, Guid? b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(Guid? a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid? a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Guid? a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(Guid? a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(Guid? a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(Guid? a, NullableGuidCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new NullableGuidExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(NullableGuidCastFunctionExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidCastFunctionExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableGuidCastFunctionExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableGuidCastFunctionExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableGuidCastFunctionExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableGuidCastFunctionExpression a, GuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableGuidCastFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableGuidCastFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableGuidCastFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableGuidCastFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableGuidCastFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableGuidCastFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
