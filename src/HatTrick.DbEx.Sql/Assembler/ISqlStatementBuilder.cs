using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlStatementBuilder
    {
        #region interface
        ISqlParameterBuilder Parameters { get; }
        IAppender Appender { get; }
        #endregion

        #region methods
        SqlStatement CreateSqlStatement();

        void AppendPart(ExpressionContainer part, AssemblyContext context);

        void AppendPart<T>(T part, AssemblyContext context)
            where T : class, IDbExpression;

        string GenerateAlias();
        #endregion
    }
}
