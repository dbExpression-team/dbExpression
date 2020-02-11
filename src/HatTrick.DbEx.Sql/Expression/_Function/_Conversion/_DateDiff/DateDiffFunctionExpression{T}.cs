using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class DateDiffFunctionExpression<TValue> : DateDiffFunctionExpression,
        ISupportedForSelectFieldExpression<int>,
        ISupportedForFunctionExpression<CountFunctionExpression, int>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, int>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, int>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, int>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, int>,
        IEquatable<DateDiffFunctionExpression<TValue>>
    {
        #region constructors
        internal DateDiffFunctionExpression()
        {
        }

        public DateDiffFunctionExpression((Type, object) datePart, (Type, object) startDate, (Type, object) endDate)
            : base(datePart, startDate, endDate)
        {
        }
        #endregion

        #region as
        public new DateDiffFunctionExpression<TValue> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateDiffFunctionExpression<TValue> obj)
            => obj is DateDiffFunctionExpression<TValue> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateDiffFunctionExpression<TValue> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        //MILESTONE: Function Arithmetic
        //public static implicit operator ExpressionMediator<TValue>(DateDiffFunctionExpression<TValue> dateDiff) => new ExpressionMediator<TValue>((dateDiff.GetType(), dateDiff));
        public static implicit operator OrderByExpression(DateDiffFunctionExpression<TValue> dateDiff) => new OrderByExpression((dateDiff.GetType(), dateDiff), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DateDiffFunctionExpression<TValue> dateDiff) => new GroupByExpression((dateDiff.GetType(), dateDiff));
        #endregion

        #region filter operators
        #region TValue
        #region int
        public static FilterExpression<int> operator ==(DateDiffFunctionExpression<TValue> a, int b) => new FilterExpression<int>(a, new LiteralExpression<int>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(DateDiffFunctionExpression<TValue> a, int b) => new FilterExpression<int>(a, new LiteralExpression<int>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(DateDiffFunctionExpression<TValue> a, int b) => new FilterExpression<int>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(DateDiffFunctionExpression<TValue> a, int b) => new FilterExpression<int>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(DateDiffFunctionExpression<TValue> a, int b) => new FilterExpression<int>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(DateDiffFunctionExpression<TValue> a, int b) => new FilterExpression<int>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int> operator ==(int a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(new LiteralExpression<int>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(int a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(new LiteralExpression<int>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(int a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(int a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(int a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(int a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(DateDiffFunctionExpression<TValue> a, int? b) => new FilterExpression<int?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(DateDiffFunctionExpression<TValue> a, int? b) => new FilterExpression<int?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(DateDiffFunctionExpression<TValue> a, int? b) => new FilterExpression<int?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(DateDiffFunctionExpression<TValue> a, int? b) => new FilterExpression<int?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(DateDiffFunctionExpression<TValue> a, int? b) => new FilterExpression<int?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(DateDiffFunctionExpression<TValue> a, int? b) => new FilterExpression<int?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(int? a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(int? a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(int? a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(int? a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(int? a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(int? a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        #region int
        public static FilterExpression<int> operator ==(DateDiffFunctionExpression<TValue> a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(DateDiffFunctionExpression<TValue> a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(DateDiffFunctionExpression<TValue> a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(DateDiffFunctionExpression<TValue> a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(DateDiffFunctionExpression<TValue> a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(DateDiffFunctionExpression<TValue> a, ExpressionMediator<int> b) => new FilterExpression<int>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int> operator ==(ExpressionMediator<int> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int> operator !=(ExpressionMediator<int> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int> operator <(ExpressionMediator<int> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int> operator <=(ExpressionMediator<int> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int> operator >(ExpressionMediator<int> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int> operator >=(ExpressionMediator<int> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(DateDiffFunctionExpression<TValue> a, NullableExpressionMediator<int?> b) => new FilterExpression<int?>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(DateDiffFunctionExpression<TValue> a, NullableExpressionMediator<int?> b) => new FilterExpression<int?>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(DateDiffFunctionExpression<TValue> a, NullableExpressionMediator<int?> b) => new FilterExpression<int?>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(DateDiffFunctionExpression<TValue> a, NullableExpressionMediator<int?> b) => new FilterExpression<int?>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(DateDiffFunctionExpression<TValue> a, NullableExpressionMediator<int?> b) => new FilterExpression<int?>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(DateDiffFunctionExpression<TValue> a, NullableExpressionMediator<int?> b) => new FilterExpression<int?>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<int?> operator ==(NullableExpressionMediator<int?> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<int?> operator !=(NullableExpressionMediator<int?> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<int?> operator <(NullableExpressionMediator<int?> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<int?> operator <=(NullableExpressionMediator<int?> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<int?> operator >(NullableExpressionMediator<int?> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<int?> operator >=(NullableExpressionMediator<int?> a, DateDiffFunctionExpression<TValue> b) => new FilterExpression<int?>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
        #endregion
    }
}
