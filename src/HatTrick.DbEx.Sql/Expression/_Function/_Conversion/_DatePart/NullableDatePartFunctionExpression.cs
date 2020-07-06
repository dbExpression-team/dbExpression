namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDatePartFunctionExpression : DatePartFunctionExpression
    {
        #region constructors
        protected NullableDatePartFunctionExpression(ExpressionContainer datePart, ExpressionMediator expression) : base(datePart, expression)
        {
        }
        #endregion
    }
}
