using HTL.DbEx.Sql.Builder;
using HTL.DbEx.Sql.Builder.Syntax;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Builder
{
    public class MsSqlBuilder<T> : SqlBuilder<T>,
        IValueContinuationBuilder<T>,
        IValueListContinuationBuilder<T>
    {
        public MsSqlBuilder(DBExpressionSet expression) : base(expression)
        { }
    }
}