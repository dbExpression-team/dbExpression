using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringFieldExpression
    {
        #region in value set
        public override FilterExpression<bool> In(params string[] value) => value is object ? new FilterExpression<bool>(new StringExpressionMediator(this), new NullableStringExpressionMediator(new InExpression<string>(value)), FilterExpressionOperator.None) : null;
        public override FilterExpression<bool> In(IEnumerable<string> value) => value is object ? new FilterExpression<bool>(new StringExpressionMediator(this), new NullableStringExpressionMediator(new InExpression<string>(value)), FilterExpressionOperator.None) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(string value) => new AssignmentExpression(this, new StringExpressionMediator(new LiteralExpression<string>(value)));
        public override AssignmentExpression Set(ExpressionMediator<string> value) => new AssignmentExpression(this, value);

        #endregion

        #region insert
        public override InsertExpression Insert(string value) => new InsertExpression(this, new StringExpressionMediator(new LiteralExpression<string>(value)));

        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableStringExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableStringExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<string>(NullableStringFieldExpression a) => new SelectExpression<string>(new NullableStringExpressionMediator(a));
        public static implicit operator NullableStringExpressionMediator(NullableStringFieldExpression a) => new NullableStringExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableStringFieldExpression a) => new OrderByExpression(new NullableStringExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableStringFieldExpression a) => new GroupByExpression(new NullableStringExpressionMediator(a));
        #endregion

        #region arithmetic operators
        #region data type
        #endregion

        #region fields

        

        

        

        

        

        

        

        

        

        

        

        
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<bool?> operator ==(NullableStringFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new NullableStringExpressionMediator(new NullableLiteralExpression<string>()), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableStringFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new NullableStringExpressionMediator(new NullableLiteralExpression<string>()), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator ==(DBNull a, NullableStringFieldExpression b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(new NullableLiteralExpression<string>()), new NullableStringExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DBNull a, NullableStringFieldExpression b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(new NullableLiteralExpression<string>()), new NullableStringExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region string
        public static FilterExpression<bool?> operator ==(NullableStringFieldExpression a, string b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableStringFieldExpression a, string b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableStringFieldExpression a, string b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableStringFieldExpression a, string b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableStringFieldExpression a, string b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableStringFieldExpression a, string b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(string a, NullableStringFieldExpression b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(string a, NullableStringFieldExpression b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(string a, NullableStringFieldExpression b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(string a, NullableStringFieldExpression b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(string a, NullableStringFieldExpression b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(string a, NullableStringFieldExpression b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        
        #region mediator
        public static FilterExpression<bool?> operator ==(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool?>(new NullableStringExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
