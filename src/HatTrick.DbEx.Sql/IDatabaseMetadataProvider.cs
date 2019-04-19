namespace HatTrick.DbEx.Sql
{
    public interface IDatabaseMetadataProvider
    {
        ISqlDatabaseMetadata Database { get; }
    }
}
