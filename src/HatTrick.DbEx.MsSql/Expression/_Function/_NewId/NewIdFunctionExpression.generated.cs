using System;
using HatTrick.DbEx.Sql.Expression;


namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class NewIdFunctionExpression
    {
        #region implicit operators
        public static implicit operator GuidExpressionMediator(NewIdFunctionExpression a) => new GuidExpressionMediator(a);
        public static implicit operator OrderByExpression(NewIdFunctionExpression a) => new OrderByExpression(new GuidExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NewIdFunctionExpression a) => new GroupByExpression(new GuidExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new GuidExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new GuidExpressionMediator(this), OrderExpressionDirection.DESC);
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
        public static FilterExpression<bool> operator ==(NewIdFunctionExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(NewIdFunctionExpression a, Guid b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(Guid a, NewIdFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Guid a, NewIdFunctionExpression b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(NewIdFunctionExpression a, Guid? b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(NewIdFunctionExpression a, Guid? b) => new FilterExpression<bool>(new GuidExpressionMediator(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(Guid? a, NewIdFunctionExpression b) => new FilterExpression<bool>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Guid? a, NewIdFunctionExpression b) => new FilterExpression<bool>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new GuidExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(NewIdFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(NewIdFunctionExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new GuidExpressionMediator(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(NewIdFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NewIdFunctionExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new GuidExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
