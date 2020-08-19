namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateAddFunctionExpression : DateAddFunctionExpression
    {
        #region constructors
        protected NullableDateAddFunctionExpression(DatePartsExpression datePart, ExpressionMediator value, ExpressionMediator expression) : base(datePart, value, expression)
        {
        }
        #endregion
    }
}
