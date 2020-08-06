namespace HatTrick.DbEx.Sql
{
    public interface ISqlMetadataProvider<T>
        where T : ISqlMetadata
    {
        T Metadata { get; }
    }
}
