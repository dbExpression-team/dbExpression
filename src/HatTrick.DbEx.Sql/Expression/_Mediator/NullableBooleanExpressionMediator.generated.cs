using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<bool?>(NullableBooleanExpressionMediator a) => new SelectExpression<bool?>(a);
        public static implicit operator OrderByExpression(NullableBooleanExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableBooleanExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators 
        #region data type 
        #endregion

        #region fields
        #endregion

        #region mediators
        #endregion
        #endregion

        #region filter operators
        #region bool
        public static FilterExpressionSet operator ==(NullableBooleanExpressionMediator a, bool b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanExpressionMediator a, bool b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableBooleanExpressionMediator a, bool b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableBooleanExpressionMediator a, bool b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableBooleanExpressionMediator a, bool b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableBooleanExpressionMediator a, bool b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(bool a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(bool a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(bool a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(bool a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(bool a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(bool a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableBooleanExpressionMediator a, bool? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanExpressionMediator a, bool? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableBooleanExpressionMediator a, bool? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableBooleanExpressionMediator a, bool? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableBooleanExpressionMediator a, bool? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableBooleanExpressionMediator a, bool? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(bool? a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(bool? a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(bool? a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(bool? a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(bool? a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(bool? a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableBooleanExpressionMediator a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanExpressionMediator a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableBooleanExpressionMediator a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableBooleanExpressionMediator a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableBooleanExpressionMediator a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableBooleanExpressionMediator a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableBooleanExpressionMediator a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanExpressionMediator a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableBooleanExpressionMediator a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableBooleanExpressionMediator a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableBooleanExpressionMediator a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableBooleanExpressionMediator a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableBooleanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        
        #region mediator
        public static FilterExpressionSet operator ==(NullableBooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableBooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableBooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableBooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableBooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableBooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableBooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableBooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableBooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableBooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new BooleanExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
