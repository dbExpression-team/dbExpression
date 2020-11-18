using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanFieldExpression
    {
        #region in value set
        public override FilterExpression<bool> In(params TimeSpan[] value) => value is object ? new FilterExpression<bool>(new TimeSpanExpressionMediator(this), new NullableTimeSpanExpressionMediator(new InExpression<TimeSpan>(value)), FilterExpressionOperator.None) : null;
        public override FilterExpression<bool> In(IEnumerable<TimeSpan> value) => value is object ? new FilterExpression<bool>(new TimeSpanExpressionMediator(this), new NullableTimeSpanExpressionMediator(new InExpression<TimeSpan>(value)), FilterExpressionOperator.None) : null;
        public override FilterExpression<bool> In(params TimeSpan?[] value) => value is object ? new FilterExpression<bool>(new NullableTimeSpanExpressionMediator(this), new NullableTimeSpanExpressionMediator(new InExpression<TimeSpan?>(value)), FilterExpressionOperator.None) : null;
        public override FilterExpression<bool> In(IEnumerable<TimeSpan?> value) => value is object ? new FilterExpression<bool>(new NullableTimeSpanExpressionMediator(this), new NullableTimeSpanExpressionMediator(new InExpression<TimeSpan?>(value)), FilterExpressionOperator.None) : null;

        #endregion

        #region set
        public override AssignmentExpression Set(TimeSpan value) => new AssignmentExpression(this, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(value)));
        public virtual AssignmentExpression Set(TimeSpanElement value) => new AssignmentExpression(this, value);
        public override AssignmentExpression Set(TimeSpan? value) => new AssignmentExpression(this, new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(value)));
        public override AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(null)));
        public virtual AssignmentExpression Set(NullTimeSpanElement value) => new AssignmentExpression(this, value);

        #endregion

        #region insert
        public override InsertExpression Insert(TimeSpan value) => new InsertExpression(this, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(value)));
        public override InsertExpression Insert(TimeSpan? value) => new InsertExpression(this, new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(value)));

        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableTimeSpanExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableTimeSpanExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<TimeSpan?>(NullableTimeSpanFieldExpression a) => new SelectExpression<TimeSpan?>(new NullableTimeSpanExpressionMediator(a));
        public static implicit operator NullableTimeSpanExpressionMediator(NullableTimeSpanFieldExpression a) => new NullableTimeSpanExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableTimeSpanFieldExpression a) => new OrderByExpression(new NullableTimeSpanExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableTimeSpanFieldExpression a) => new GroupByExpression(new NullableTimeSpanExpressionMediator(a));
        #endregion

        #region arithmetic operators
        #region data type
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

        #region fields

        

        

        

        

        

        

        

        

        

        
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<bool?> operator ==(NullableTimeSpanFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>()), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableTimeSpanFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>()), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator ==(DBNull a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>()), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DBNull a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>()), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region TimeSpan
        public static FilterExpression<bool?> operator ==(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableTimeSpanFieldExpression a, TimeSpan b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new TimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new TimeSpanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new TimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new TimeSpanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new TimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new TimeSpanExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new TimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new TimeSpanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new TimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new TimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(TimeSpan a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new TimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new TimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableTimeSpanFieldExpression a, TimeSpan? b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(TimeSpan? a, NullableTimeSpanFieldExpression b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(a)), new NullableTimeSpanExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<bool?> operator ==(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableTimeSpanFieldExpression a, TimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableTimeSpanFieldExpression a, NullableTimeSpanExpressionMediator b) => new FilterExpression<bool?>(new NullableTimeSpanExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
