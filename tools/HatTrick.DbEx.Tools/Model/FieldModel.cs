using HatTrick.DbEx.Tools.Service;
using HatTrick.Model.MsSql;
using System;

namespace HatTrick.DbEx.Tools.Model
{
    public class FieldModel
    {
        private readonly MsSqlColumn _column;
        private string _namespace;
        private readonly CodeGenerationHelpers _helpers;
        private readonly TypeMapService _typeMap;
        private TypeModel _type;

        public string Namespace => $"{_helpers.ResolveRootNamespace()}{_namespace}DataService";
        public EntityModel Entity { get; }
        public string FieldName => _helpers.ResolveName(_column);
        public TypeModel Type => _type ??= new TypeModel
        {
            TypeName = _helpers.ResolveClrTypeName(_column, _column.IsNullable),
            Alias = _helpers.ResolveClrTypeName(_column, false),
            NullableAlias = _typeMap.GetNullableAliasFromTypeName(_helpers.ResolveClrTypeName(_column, false), _column.IsNullable),
            IsNullable = _typeMap.GetNullableAliasFromTypeName(_helpers.ResolveClrTypeName(_column, false), _column.IsNullable).EndsWith("?"),
            IsArray = _typeMap.GetNullableAliasFromTypeName(_helpers.ResolveClrTypeName(_column, false), _column.IsNullable).EndsWith("[]"),
        };

        public FieldModel(MsSqlColumn column, CodeGenerationHelpers helpers, TypeMapService typeMap)
        {
            _column = column ?? throw new ArgumentNullException(nameof(column));
            _helpers = helpers ?? throw new ArgumentNullException(nameof(helpers));
            _typeMap = typeMap ?? throw new ArgumentNullException(nameof(typeMap));
            Entity = new EntityModel(column.GetParent(), helpers);
            _namespace = column.GetParent() is MsSqlTable table ? helpers.ResolveName(table.GetParent()) : helpers.ResolveName((column.GetParent() as MsSqlView).GetParent());
        }

        public (string,string) CrefTypeName
        {
            get
            {
                if (Type.IsArray)
                    return (Type.TypeName.Substring(0, Type.TypeName.Length - 2), "[]");
                if (Type.IsNullable)
                    return (Type.TypeName.Substring(0, Type.TypeName.Length - 1), "?");

                return (Type.TypeName, null);
            }
        }
    }
}
