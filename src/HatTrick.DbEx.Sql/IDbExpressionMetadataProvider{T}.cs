namespace HatTrick.DbEx.Sql
{
    public interface IDbExpressionMetadataProvider<T>
        where T : IDbExpressionMetadata
    {
        T Metadata { get; }
    }
}
