namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateDiffFunctionExpression : DateDiffFunctionExpression
    {
        #region constructors
        protected NullableDateDiffFunctionExpression(ExpressionContainer datePart, ExpressionContainer startDate, ExpressionContainer endDate) : base(datePart, startDate, endDate)
        {
        }
        #endregion
    }
}
