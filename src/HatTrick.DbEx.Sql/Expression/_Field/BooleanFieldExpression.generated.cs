using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanFieldExpression
    {
        #region in value set
        public override FilterExpression<bool> In(params bool[] value) => value is object ? new FilterExpression<bool>(new BooleanExpressionMediator(this), new BooleanExpressionMediator(new InExpression<bool>(value)), FilterExpressionOperator.None) : null;
        public override FilterExpression<bool> In(IEnumerable<bool> value) => value is object ? new FilterExpression<bool>(new BooleanExpressionMediator(this), new BooleanExpressionMediator(new InExpression<bool>(value)), FilterExpressionOperator.None) : null;
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
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<bool?> operator ==(BooleanFieldExpression a, DBNull b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>()), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(BooleanFieldExpression a, DBNull b) => new FilterExpression<bool?>(new BooleanExpressionMediator(a), new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>()), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator ==(DBNull a, BooleanFieldExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>()), new BooleanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DBNull a, BooleanFieldExpression b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>()), new BooleanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion

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
        #endregion
    }
}
