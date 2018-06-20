using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public class MsSqlBuilder<T> : SqlBuilder<T>,
        ISelectContinuationBuilder<T>,
        ISelectAllContinuationBuilder<T>
    {
        public MsSqlBuilder(DBExpressionSet expression) : base(expression)
        { }
    }
}