namespace HatTrick.DbEx.Tools.Model
{
    public class TypeModel
    { 
        public string TypeName { get; set; }
        public string Alias { get; set; }
        public string NullableAlias { get; set; }
        public bool IsNullable { get; set; }
        public bool IsArray { get; set; }
        public bool IsEnum { get; set; }

        public TypeModel(string typeName, string alias, bool isNullable, bool isArray = false)
        {
            TypeName = typeName;
            Alias = alias;
            NullableAlias = isNullable ? $"{alias}?" : alias;
            IsNullable = isNullable;
            IsArray = isArray;
        }
    }
}
