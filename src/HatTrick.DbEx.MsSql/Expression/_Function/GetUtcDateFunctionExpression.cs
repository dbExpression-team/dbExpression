using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public class GetUtcDateFunctionExpression :
        IDbDateFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectFieldExpression<DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime>,
        IEquatable<GetUtcDateFunctionExpression>
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        string IDbExpressionAliasProvider.Alias => Alias;
        public OrderByExpression Asc => new OrderByExpression((GetType(), this), OrderExpressionDirection.ASC);
        public OrderByExpression Desc => new OrderByExpression((GetType(), this), OrderExpressionDirection.DESC);
        #endregion

        #region as
        public GetUtcDateFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "GetUtcDate()";
        #endregion

        #region equals
        public bool Equals(GetUtcDateFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is GetUtcDateFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        //MILESTONE: Function Arithmetic
        //public static implicit operator ExpressionMediator<DateTime>(GetUtcDateFunctionExpression date) => new ExpressionMediator<DateTime>((date.GetType(), date));
        public static implicit operator GroupByExpression(GetUtcDateFunctionExpression a) => new GroupByExpression((typeof(GetUtcDateFunctionExpression), a));
        public static implicit operator OrderByExpression(GetUtcDateFunctionExpression date) => new OrderByExpression((date.GetType(), date), OrderExpressionDirection.ASC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region DateTime
        public static ExpressionMediator<DateTime> operator +(GetUtcDateFunctionExpression a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(GetUtcDateFunctionExpression a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(GetUtcDateFunctionExpression a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(GetUtcDateFunctionExpression a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(GetUtcDateFunctionExpression a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTime> operator +(DateTime a, GetUtcDateFunctionExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(DateTime a, GetUtcDateFunctionExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(DateTime a, GetUtcDateFunctionExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(DateTime a, GetUtcDateFunctionExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(DateTime a, GetUtcDateFunctionExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(GetUtcDateFunctionExpression a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(GetUtcDateFunctionExpression a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(GetUtcDateFunctionExpression a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(GetUtcDateFunctionExpression a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(GetUtcDateFunctionExpression a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(DateTime? a, GetUtcDateFunctionExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(DateTime? a, GetUtcDateFunctionExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(DateTime? a, GetUtcDateFunctionExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(DateTime? a, GetUtcDateFunctionExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(DateTime? a, GetUtcDateFunctionExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTimeOffset
        public static ExpressionMediator<DateTimeOffset> operator +(GetUtcDateFunctionExpression a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(GetUtcDateFunctionExpression a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(GetUtcDateFunctionExpression a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(GetUtcDateFunctionExpression a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(GetUtcDateFunctionExpression a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTimeOffset> operator +(DateTimeOffset a, GetUtcDateFunctionExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(DateTimeOffset a, GetUtcDateFunctionExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(DateTimeOffset a, GetUtcDateFunctionExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(DateTimeOffset a, GetUtcDateFunctionExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(DateTimeOffset a, GetUtcDateFunctionExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(GetUtcDateFunctionExpression a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(GetUtcDateFunctionExpression a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(GetUtcDateFunctionExpression a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(GetUtcDateFunctionExpression a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(GetUtcDateFunctionExpression a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(DateTimeOffset? a, GetUtcDateFunctionExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(DateTimeOffset? a, GetUtcDateFunctionExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(DateTimeOffset? a, GetUtcDateFunctionExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(DateTimeOffset? a, GetUtcDateFunctionExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(DateTimeOffset? a, GetUtcDateFunctionExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region mediator
        #region DateTime
        public static ExpressionMediator<DateTime> operator +(GetUtcDateFunctionExpression a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(GetUtcDateFunctionExpression a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(GetUtcDateFunctionExpression a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(GetUtcDateFunctionExpression a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(GetUtcDateFunctionExpression a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTimeOffset
        public static ExpressionMediator<DateTimeOffset> operator +(GetUtcDateFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(GetUtcDateFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(GetUtcDateFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(GetUtcDateFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(GetUtcDateFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTime
        public static FilterExpression<DateTime> operator ==(GetUtcDateFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(GetUtcDateFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(GetUtcDateFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(GetUtcDateFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(GetUtcDateFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(GetUtcDateFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(DateTime a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(DateTime a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(DateTime a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(DateTime a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(DateTime a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(GetUtcDateFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(GetUtcDateFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(GetUtcDateFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(GetUtcDateFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(GetUtcDateFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(GetUtcDateFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(DateTime? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(DateTime? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(DateTime? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(DateTime? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(DateTime? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(DateTime? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTimeOffset
        public static FilterExpression<DateTimeOffset> operator ==(GetUtcDateFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(GetUtcDateFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(GetUtcDateFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(GetUtcDateFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(GetUtcDateFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(GetUtcDateFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(GetUtcDateFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(GetUtcDateFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(GetUtcDateFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(GetUtcDateFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(GetUtcDateFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(GetUtcDateFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(DateTimeOffset? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(DateTimeOffset? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(DateTimeOffset? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(DateTimeOffset? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(DateTimeOffset? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(DateTimeOffset? a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        #region DateTime
        public static FilterExpression<DateTime> operator ==(GetUtcDateFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(GetUtcDateFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(GetUtcDateFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(GetUtcDateFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(GetUtcDateFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(GetUtcDateFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(ExpressionMediator<DateTime> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(ExpressionMediator<DateTime> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(ExpressionMediator<DateTime> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(ExpressionMediator<DateTime> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(ExpressionMediator<DateTime> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(ExpressionMediator<DateTime> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(NullableExpressionMediator<DateTime?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(NullableExpressionMediator<DateTime?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(NullableExpressionMediator<DateTime?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(NullableExpressionMediator<DateTime?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(NullableExpressionMediator<DateTime?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(NullableExpressionMediator<DateTime?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTimeOffset
        public static FilterExpression<DateTimeOffset> operator ==(GetUtcDateFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(GetUtcDateFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(GetUtcDateFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(GetUtcDateFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(GetUtcDateFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(GetUtcDateFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(ExpressionMediator<DateTimeOffset> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(ExpressionMediator<DateTimeOffset> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(ExpressionMediator<DateTimeOffset> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(ExpressionMediator<DateTimeOffset> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(ExpressionMediator<DateTimeOffset> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(ExpressionMediator<DateTimeOffset> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(GetUtcDateFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(NullableExpressionMediator<DateTimeOffset?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(NullableExpressionMediator<DateTimeOffset?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(NullableExpressionMediator<DateTimeOffset?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(NullableExpressionMediator<DateTimeOffset?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(NullableExpressionMediator<DateTimeOffset?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(NullableExpressionMediator<DateTimeOffset?> a, GetUtcDateFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
        #endregion
    }
}
