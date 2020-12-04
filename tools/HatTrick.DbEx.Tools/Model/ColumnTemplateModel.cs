using HatTrick.DbEx.Tools.Service;
using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Data;

namespace HatTrick.DbEx.Tools.Model
{
    public class ColumnTemplateModel
    {
        private readonly MsSqlColumn _column;

        public ISqlEntityModel Parent { get; }
        public string ColumnName => _column.Name;
        public bool IsNullable => _column.IsNullable;
        public IDictionary<string, string> Properties { get; }
        public FieldModel Field { get; }

        public ColumnTemplateModel(MsSqlColumn column, CodeGenerationHelpers helpers, TypeMapService typeMap)
        {
            _column = column ?? throw new ArgumentNullException(nameof(column));
            Parent = _column.GetParent() is MsSqlTable table ? (ISqlEntityModel)(new TableTemplateModel(table, helpers)) : new ViewTemplateModel(_column.GetParent() as MsSqlView, helpers);
            Properties = BuildColumnDocumentationMetadata(column);
            Field = new FieldModel(column, helpers, typeMap ?? throw new ArgumentNullException(nameof(typeMap)));
        }

        private IDictionary<string, string> BuildColumnDocumentationMetadata(MsSqlColumn column)
        {
            var attributes = new Dictionary<string, string>();

            attributes.Add("name", column.Name);
            attributes.Add("sql type", GetDocumentationTypeName(column));
            attributes.Add("allow null", column.IsNullable ? "yes" : "no");
            if (!string.IsNullOrWhiteSpace(column.DefaultDefinition))
                attributes.Add("default", column.DefaultDefinition);
            if (column.IsIdentity)
                attributes.Add("identity", "yes");
            if (column.IsComputed)
                attributes.Add("computed", "yes");

            return attributes;
        }

        private string GetDocumentationTypeName(MsSqlColumn column)
        {
            switch (column.SqlType)
            {
                case SqlDbType.Binary:
                case SqlDbType.VarBinary:
                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NVarChar:
                case SqlDbType.VarChar: return $"{column.SqlType.ToString().ToLower()}({column.MaxLength})";

                case SqlDbType.Decimal:
                    return $"{column.SqlType.ToString().ToLower()}({column.Precision}{(column.Scale > 0 ? $",{column.Scale}" : string.Empty)})";

                default:
                    return column.SqlType.ToString().ToLower();
            }
        }
    }
}
