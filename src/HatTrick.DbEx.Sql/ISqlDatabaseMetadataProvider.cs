namespace HatTrick.DbEx.Sql
{
    public interface ISqlDatabaseMetadataProvider
    {
        ISqlDatabaseMetadata Database { get; }
    }
}
