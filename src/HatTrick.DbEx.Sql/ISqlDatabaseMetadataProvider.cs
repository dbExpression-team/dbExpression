namespace HatTrick.DbEx.Sql
{
    public interface ISqlDatabaseMetadataProvider
    {
        ISqlDatabaseMetadata Database { get; }
        ISqlSchemaMetadata FindSchemaMetadata(string identifier);
        ISqlEntityMetadata FindEntityMetadata(string identifier);
        ISqlFieldMetadata FindFieldMetadata(string identifier);
    }
}
