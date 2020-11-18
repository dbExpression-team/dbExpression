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

        void AppendElement<T>(T element, AssemblyContext context)
            where T : class, IExpressionElement;

        string GenerateAlias();

        ISqlSchemaMetadata FindMetadata(SchemaExpression schema);
        ISqlEntityMetadata FindMetadata(EntityExpression entity);
        ISqlFieldMetadata FindMetadata(FieldExpression field);
        #endregion
    }
}
