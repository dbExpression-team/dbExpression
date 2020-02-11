using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public class NewIdFunctionExpression :
        IDbNumericFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectFieldExpression<DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        IEquatable<NewIdFunctionExpression>
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
        public NewIdFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "NEWID()";
        #endregion

        #region equals
        public bool Equals(NewIdFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is NewIdFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        //MILESTONE: Function Arithmetic
        //public static implicit operator ExpressionMediator<Guid>(NewIdFunctionExpression newId) => new ExpressionMediator<Guid>((newId.GetType(), newId));
        public static implicit operator OrderByExpression(NewIdFunctionExpression newId) => new OrderByExpression((newId.GetType(), newId), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NewIdFunctionExpression newId) => new GroupByExpression((newId.GetType(), newId));
        #endregion

        #region filter operators
        #region TValue
        #region Guid
        public static FilterExpression<Guid> operator ==(NewIdFunctionExpression a, Guid b) => new FilterExpression<Guid>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(NewIdFunctionExpression a, Guid b) => new FilterExpression<Guid>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(NewIdFunctionExpression a, Guid b) => new FilterExpression<Guid>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(NewIdFunctionExpression a, Guid b) => new FilterExpression<Guid>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(NewIdFunctionExpression a, Guid b) => new FilterExpression<Guid>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(NewIdFunctionExpression a, Guid b) => new FilterExpression<Guid>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(Guid a, NewIdFunctionExpression b) => new FilterExpression<Guid>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(Guid a, NewIdFunctionExpression b) => new FilterExpression<Guid>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(Guid a, NewIdFunctionExpression b) => new FilterExpression<Guid>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(Guid a, NewIdFunctionExpression b) => new FilterExpression<Guid>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(Guid a, NewIdFunctionExpression b) => new FilterExpression<Guid>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(Guid a, NewIdFunctionExpression b) => new FilterExpression<Guid>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(NewIdFunctionExpression a, Guid? b) => new FilterExpression<Guid?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(NewIdFunctionExpression a, Guid? b) => new FilterExpression<Guid?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(NewIdFunctionExpression a, Guid? b) => new FilterExpression<Guid?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(NewIdFunctionExpression a, Guid? b) => new FilterExpression<Guid?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(NewIdFunctionExpression a, Guid? b) => new FilterExpression<Guid?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(NewIdFunctionExpression a, Guid? b) => new FilterExpression<Guid?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(Guid? a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(Guid? a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(Guid? a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(Guid? a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(Guid? a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(Guid? a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        #region Guid
        public static FilterExpression<Guid> operator ==(NewIdFunctionExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(NewIdFunctionExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(NewIdFunctionExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(NewIdFunctionExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(NewIdFunctionExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(NewIdFunctionExpression a, ExpressionMediator<Guid> b) => new FilterExpression<Guid>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid> operator ==(ExpressionMediator<Guid> a, NewIdFunctionExpression b) => new FilterExpression<Guid>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid> operator !=(ExpressionMediator<Guid> a, NewIdFunctionExpression b) => new FilterExpression<Guid>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator <(ExpressionMediator<Guid> a, NewIdFunctionExpression b) => new FilterExpression<Guid>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid> operator <=(ExpressionMediator<Guid> a, NewIdFunctionExpression b) => new FilterExpression<Guid>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid> operator >(ExpressionMediator<Guid> a, NewIdFunctionExpression b) => new FilterExpression<Guid>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid> operator >=(ExpressionMediator<Guid> a, NewIdFunctionExpression b) => new FilterExpression<Guid>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(NewIdFunctionExpression a, NullableExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(NewIdFunctionExpression a, NullableExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(NewIdFunctionExpression a, NullableExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(NewIdFunctionExpression a, NullableExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(NewIdFunctionExpression a, NullableExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(NewIdFunctionExpression a, NullableExpressionMediator<Guid?> b) => new FilterExpression<Guid?>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<Guid?> operator ==(NullableExpressionMediator<Guid?> a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<Guid?> operator !=(NullableExpressionMediator<Guid?> a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator <(NullableExpressionMediator<Guid?> a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<Guid?> operator <=(NullableExpressionMediator<Guid?> a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<Guid?> operator >(NullableExpressionMediator<Guid?> a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<Guid?> operator >=(NullableExpressionMediator<Guid?> a, NewIdFunctionExpression b) => new FilterExpression<Guid?>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
        #endregion
    }
}
