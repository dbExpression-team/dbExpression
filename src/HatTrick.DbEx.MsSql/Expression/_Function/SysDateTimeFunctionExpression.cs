using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public class SysDateTimeFunctionExpression :
        IDbDateFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectFieldExpression<DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression, DateTime>,
        IEquatable<SysDateTimeFunctionExpression>
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
        public SysDateTimeFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "SysDateTime()";
        #endregion

        #region equals
        public bool Equals(SysDateTimeFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is SysDateTimeFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        //MILESTONE: Function Arithmetic
        //public static implicit operator ExpressionMediator<DateTime>(SysDateTimeFunctionExpression date) => new ExpressionMediator<DateTime>((date.GetType(), date));
        public static implicit operator GroupByExpression(SysDateTimeFunctionExpression a) => new GroupByExpression((typeof(SysDateTimeFunctionExpression), a));
        public static implicit operator OrderByExpression(SysDateTimeFunctionExpression date) => new OrderByExpression((date.GetType(), date), OrderExpressionDirection.ASC);
        #endregion

        #region filter operators
        #region TValue
        #region DateTime
        public static FilterExpression<DateTime> operator ==(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<DateTime?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTimeOffset
        public static FilterExpression<DateTimeOffset> operator ==(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(SysDateTimeFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(SysDateTimeFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(SysDateTimeFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(SysDateTimeFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(SysDateTimeFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(SysDateTimeFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(SysDateTimeFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(DateTimeOffset? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(DateTimeOffset? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(DateTimeOffset? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(DateTimeOffset? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(DateTimeOffset? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(DateTimeOffset? a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        #region DateTime
        public static FilterExpression<DateTime> operator ==(SysDateTimeFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(SysDateTimeFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(SysDateTimeFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(SysDateTimeFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(SysDateTimeFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(SysDateTimeFunctionExpression a, ExpressionMediator<DateTime> b) => new FilterExpression<DateTime>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(ExpressionMediator<DateTime> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime> operator !=(ExpressionMediator<DateTime> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime> operator <(ExpressionMediator<DateTime> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime> operator <=(ExpressionMediator<DateTime> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime> operator >(ExpressionMediator<DateTime> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime> operator >=(ExpressionMediator<DateTime> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTime?> b) => new FilterExpression<DateTime?>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(NullableExpressionMediator<DateTime?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTime?> operator !=(NullableExpressionMediator<DateTime?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTime?> operator <(NullableExpressionMediator<DateTime?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTime?> operator <=(NullableExpressionMediator<DateTime?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTime?> operator >(NullableExpressionMediator<DateTime?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTime?> operator >=(NullableExpressionMediator<DateTime?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTime?>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTimeOffset
        public static FilterExpression<DateTimeOffset> operator ==(SysDateTimeFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(SysDateTimeFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(SysDateTimeFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(SysDateTimeFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(SysDateTimeFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(SysDateTimeFunctionExpression a, ExpressionMediator<DateTimeOffset> b) => new FilterExpression<DateTimeOffset>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(ExpressionMediator<DateTimeOffset> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset> operator !=(ExpressionMediator<DateTimeOffset> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset> operator <(ExpressionMediator<DateTimeOffset> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset> operator <=(ExpressionMediator<DateTimeOffset> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator >(ExpressionMediator<DateTimeOffset> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset> operator >=(ExpressionMediator<DateTimeOffset> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(SysDateTimeFunctionExpression a, NullableExpressionMediator<DateTimeOffset?> b) => new FilterExpression<DateTimeOffset?>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(NullableExpressionMediator<DateTimeOffset?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<DateTimeOffset?> operator !=(NullableExpressionMediator<DateTimeOffset?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<DateTimeOffset?> operator <(NullableExpressionMediator<DateTimeOffset?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<DateTimeOffset?> operator <=(NullableExpressionMediator<DateTimeOffset?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator >(NullableExpressionMediator<DateTimeOffset?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<DateTimeOffset?> operator >=(NullableExpressionMediator<DateTimeOffset?> a, SysDateTimeFunctionExpression b) => new FilterExpression<DateTimeOffset?>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
        #endregion
    }
}
