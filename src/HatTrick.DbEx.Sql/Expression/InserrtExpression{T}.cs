namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertExpression<T> :
        InsertExpression
    {
        #region constructors
        public InsertExpression(FieldExpression field, T assignment)
            : base(field, new LiteralExpression<T>(assignment))
        {
        }
        #endregion
    }
}
