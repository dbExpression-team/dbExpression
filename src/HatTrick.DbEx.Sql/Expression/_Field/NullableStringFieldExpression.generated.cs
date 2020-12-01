using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringFieldExpression
    {
        #region in value set
        public override FilterExpressionSet In(params string[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<string>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<string> value) => value is object ? new FilterExpression<bool>(this, new InExpression<string>(value), FilterExpressionOperator.None) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
        public virtual AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableStringExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableStringExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<string>(NullableStringFieldExpression a) => new SelectExpression<string>(a);
        public static implicit operator NullableStringExpressionMediator(NullableStringFieldExpression a) => new NullableStringExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableStringFieldExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableStringFieldExpression a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region data types
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
        public static NullableStringExpressionMediator operator +(NullableStringFieldExpression a, string b) => new NullableStringExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Add));

        public static NullableStringExpressionMediator operator +(string a, NullableStringFieldExpression b) => new NullableStringExpressionMediator(new ArithmeticExpression(new LiteralExpression<string>(a), b, ArithmeticExpressionOperator.Add));

        #endregion        

        #region TimeSpan



        #endregion        

        #endregion

        #region fields











        #region string
        public static NullableStringExpressionMediator operator +(NullableStringFieldExpression a, StringFieldExpression b) => new NullableStringExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));

        public static NullableStringExpressionMediator operator +(NullableStringFieldExpression a, NullableStringFieldExpression b) => new NullableStringExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        #endregion


        #endregion

        #region mediators











        #region string
        public static NullableStringExpressionMediator operator +(NullableStringFieldExpression a, StringExpressionMediator b) => new NullableStringExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));

        public static NullableStringExpressionMediator operator +(NullableStringFieldExpression a, NullableStringExpressionMediator b) => new NullableStringExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        #endregion


        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableStringFieldExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableStringFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableStringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableStringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data types
        #region string
        public static FilterExpressionSet operator ==(NullableStringFieldExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringFieldExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringFieldExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringFieldExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringFieldExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringFieldExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(string a, NullableStringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(string a, NullableStringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(string a, NullableStringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(string a, NullableStringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(string a, NullableStringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(string a, NullableStringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableStringFieldExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringFieldExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringFieldExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringFieldExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringFieldExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringFieldExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion
        
        #region mediators
        public static FilterExpressionSet operator ==(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringFieldExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableStringFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
