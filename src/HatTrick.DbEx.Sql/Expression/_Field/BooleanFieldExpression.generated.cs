using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanFieldExpression
    {
        #region in value set
        public override FilterExpression In(params bool[] value) => value is object ? new FilterExpression<bool>(new BooleanExpressionMediator(this), new BooleanExpressionMediator(new LiteralExpression<bool[]>(value)), FilterExpressionOperator.In) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(bool value) => new AssignmentExpression(this, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));
        public override AssignmentExpression Set(ExpressionMediator<bool> value) => new AssignmentExpression(this, value);
        #endregion

        #region insert
        public override InsertExpression Insert(bool value) => new InsertExpression(this, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new BooleanExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new BooleanExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<bool>(BooleanFieldExpression a) => new SelectExpression<bool>(new BooleanExpressionMediator(a));
        public static implicit operator BooleanExpressionMediator(BooleanFieldExpression a) => new BooleanExpressionMediator(a);
        public static implicit operator OrderByExpression(BooleanFieldExpression a) => new OrderByExpression(new BooleanExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(BooleanFieldExpression a) => new GroupByExpression(new BooleanExpressionMediator(a));
        #endregion

        #region arithmetic operators
        #region data type
        #endregion

        #region fields
        #endregion

        #region alias
        //moved to non-generated file
        #endregion
        #endregion

        #region filter operators
        #region bool
        public static FilterExpression<bool> operator ==(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(BooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(BooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(BooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(BooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(BooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(BooleanFieldExpression a, bool? b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(bool? a, BooleanFieldExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(bool? a, BooleanFieldExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(bool? a, BooleanFieldExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(bool? a, BooleanFieldExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(bool? a, BooleanFieldExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(bool? a, BooleanFieldExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new BooleanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<bool> operator ==(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region alias
        public static FilterExpression<bool> operator ==(BooleanFieldExpression a, AliasExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanFieldExpression a, AliasExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanFieldExpression a, AliasExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanFieldExpression a, AliasExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanFieldExpression a, AliasExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanFieldExpression a, AliasExpression b) => new FilterExpression<bool>(new BooleanExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
