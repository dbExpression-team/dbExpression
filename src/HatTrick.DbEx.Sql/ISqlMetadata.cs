namespace HatTrick.DbEx.Sql
{
    public interface ISqlMetadata : ISqlMetadataIdentifier, ISqlMetadataName
    {
    }

    public interface ISqlMetadataIdentifier
    { 
        string Identifier { get; }
    
    }

    public interface ISqlMetadataName
    {
        string Name { get; }

    }
}
