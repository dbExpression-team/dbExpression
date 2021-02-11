namespace HatTrick.DbEx.Sql
{
    public interface ISqlFieldMetadata : ISqlMetadata
    {
        ISqlEntityMetadata Entity { get; }
        bool IsIdentity { get; }
        int? Size { get; }
        byte? Precision { get; }
        byte? Scale { get; }
        object DbType { get; }
    }
}
