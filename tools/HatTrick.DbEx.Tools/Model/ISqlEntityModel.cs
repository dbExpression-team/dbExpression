namespace HatTrick.DbEx.Tools.Model
{
    public interface ISqlEntityModel
    {
        string SchemaName { get; }
        string Name { get; }
        string TypeName { get; }
        DocumentationPropertiesModel Documentation { get; }
    }
}
