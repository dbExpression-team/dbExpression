using HTL.DbEx.ObjectMap;

namespace HTL.DbEx
{
    public static partial class FieldExtensions
    {
        public static string ResolveAssemblyPropertyName(this Field field) => string.IsNullOrWhiteSpace(field.AliasName) ? field.Name : field.AliasName;
    }
}
