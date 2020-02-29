using System;
using HatTrick.DbEx.Sql.Expression;


namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class NewIdFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<Guid>(NewIdFunctionExpression a) => new SelectExpression<Guid>(new ExpressionContainer(a));
        public static implicit operator GuidExpressionMediator(NewIdFunctionExpression a) => new GuidExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(NewIdFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NewIdFunctionExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #endregion

        #region mediator
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region Guid
        public static FilterExpression<Guid> operator ==(NewIdFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(NewIdFunctionExpression a, Guid b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator ==(Guid a, NewIdFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(Guid a, NewIdFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator ==(NewIdFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(NewIdFunctionExpression a, Guid? b) => new FilterExpression<Guid>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid> operator ==(Guid? a, NewIdFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(Guid? a, NewIdFunctionExpression b) => new FilterExpression<Guid>(new ExpressionContainer(new LiteralExpression<Guid?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<Guid> operator ==(NewIdFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<Guid> operator !=(NewIdFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<Guid>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<Guid?> operator ==(NewIdFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<Guid?> operator !=(NewIdFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<Guid?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
