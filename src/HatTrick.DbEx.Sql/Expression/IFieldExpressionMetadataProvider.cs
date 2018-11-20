namespace HatTrick.DbEx.Sql.Expression
{
    public interface IExpressionMetadataProvider<T>
        where T : IExpressionMetadata
    {
        T Metadata { get; }
    }
}
