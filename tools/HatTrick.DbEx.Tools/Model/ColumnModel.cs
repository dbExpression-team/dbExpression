using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Data;

namespace HatTrick.DbEx.Tools.Model
{
    public class ColumnModel
    {
        private readonly MsSqlColumn _column;

        public ISqlEntityModel Entity { get; }
        public string Name => _column.Name;
        public bool IsNullable => _column.IsNullable;
        public bool IsIdentity => _column.IsIdentity;
        public bool IsComputed => _column.IsComputed;
        public short MaxLength => _column.MaxLength;
        public IDictionary<string, string> Properties { get; }
        public SqlDbType SqlType => _column.SqlType;

        public ColumnModel(ISqlEntityModel entity, MsSqlColumn column)
        {
            Entity = entity;
            _column = column ?? throw new ArgumentNullException(nameof(column));
            Properties = BuildColumnDocumentationMetadata(column);
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
                case SqlDbType.VarChar: return $"{column.SqlType.ToString().ToLower()}({(column.MaxLength == -1 ? "MAX" : column.MaxLength.ToString())})";
                
                case SqlDbType.NChar:
                case SqlDbType.NVarChar: return $"{column.SqlType.ToString().ToLower()}({(column.MaxLength == -1 ? "MAX" : (column.MaxLength / 2).ToString())})";

                case SqlDbType.Decimal:
                    return $"{column.SqlType.ToString().ToLower()}({column.Precision}{(column.Scale > 0 ? $",{column.Scale}" : string.Empty)})";

                default:
                    return column.SqlType.ToString().ToLower();
            }
        }
    }
}
