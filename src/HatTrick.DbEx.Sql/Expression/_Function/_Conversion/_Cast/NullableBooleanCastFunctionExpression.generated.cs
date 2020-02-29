using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<bool?>(NullableBooleanCastFunctionExpression a) => new SelectExpression<bool?>(new ExpressionContainer(a));
        public static implicit operator NullableBooleanExpressionMediator(NullableBooleanCastFunctionExpression a) => new NullableBooleanExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(NullableBooleanCastFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableBooleanCastFunctionExpression a) => new GroupByExpression(new ExpressionContainer(a));
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

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region bool
        public static FilterExpression<bool> operator ==(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
