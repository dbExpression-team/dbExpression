using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanFieldExpression
    {
        #region in value set
        public override FilterExpressionSet In(params bool[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<bool>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<bool> value) => value is object ? new FilterExpression<bool>(this, new InExpression<bool>(value), FilterExpressionOperator.None) : null;
        public override FilterExpressionSet In(params bool?[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool?>(this, new InExpression<bool?>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<bool?> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool?>(this, new InExpression<bool?>(value), FilterExpressionOperator.None)) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(bool value) => new AssignmentExpression(this, new LiteralExpression<bool>(value));
        public virtual AssignmentExpression Set(BooleanElement value) => new AssignmentExpression(this, value);
        public override AssignmentExpression Set(bool? value) => new AssignmentExpression(this, new LiteralExpression<bool?>(value));
        public override AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<bool?>(DBNull.Value));
        public virtual AssignmentExpression Set(NullableBooleanElement value) => new AssignmentExpression(this, value);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableBooleanExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableBooleanExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<bool?>(NullableBooleanFieldExpression a) => new SelectExpression<bool?>(a);
        public static implicit operator NullableBooleanExpressionMediator(NullableBooleanFieldExpression a) => new NullableBooleanExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableBooleanFieldExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableBooleanFieldExpression a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region data types
        #endregion

        #region fields
        #endregion

        #region mediators
        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableBooleanFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data types
        #region bool
        public static FilterExpressionSet operator ==(NullableBooleanFieldExpression a, bool b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanFieldExpression a, bool b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(bool a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(bool a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(NullableBooleanFieldExpression a, bool? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanFieldExpression a, bool? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(bool? a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(bool? a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableBooleanFieldExpression a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanFieldExpression a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(NullableBooleanFieldExpression a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanFieldExpression a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion
        
        #region mediators
        public static FilterExpressionSet operator ==(NullableBooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(NullableBooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableBooleanFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion
    }
}
