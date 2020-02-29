using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanFieldExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<bool?>(NullableBooleanFieldExpression a) => new SelectExpression<bool?>(new ExpressionContainer(a));
        public static implicit operator NullableBooleanExpressionMediator(NullableBooleanFieldExpression a) => new NullableBooleanExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(NullableBooleanFieldExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableBooleanFieldExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #endregion

        #region mediator
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, DBNull b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(b, typeof(DBNull)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, DBNull b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(b, typeof(DBNull)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator ==(DBNull a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(a, typeof(DBNull)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DBNull a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(a, typeof(DBNull)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region bool
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, bool b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, bool b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableBooleanFieldExpression a, bool b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableBooleanFieldExpression a, bool b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableBooleanFieldExpression a, bool b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableBooleanFieldExpression a, bool b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(bool a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(bool a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(bool a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(bool a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(bool a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(bool a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableBooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableBooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableBooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableBooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(bool? a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(bool? a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(bool? a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(bool? a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(bool? a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(bool? a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableBooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableBooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableBooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableBooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableBooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableBooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableBooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableBooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableBooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableBooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
