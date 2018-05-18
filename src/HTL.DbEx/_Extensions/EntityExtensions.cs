using HTL.DbEx.ObjectMap;

namespace HTL.DbEx
{
    public static partial class EntityExtensions
    {
        public static string ResolveAssemblyEntityName(this Entity entity) => string.IsNullOrWhiteSpace(entity.AliasName) ? entity.Name : entity.AliasName;
    }
}
