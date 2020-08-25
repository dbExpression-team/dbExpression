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

        void AppendPart<T>(T part, AssemblyContext context)
            where T : class, IExpression;

        string GenerateAlias();

        ISqlSchemaMetadata FindMetadata(SchemaExpression schema);
        ISqlEntityMetadata FindMetadata(EntityExpression entity);
        ISqlFieldMetadata FindMetadata(FieldExpression field);
        #endregion
    }
}
