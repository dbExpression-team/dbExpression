using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Data;

namespace HatTrick.DbEx.Tools.Model
{
    public class ColumnModel
    {
        public ISqlEntityModel Entity { get; }
        public string Name { get; }
        public bool IsNullable { get; }
        public bool IsIdentity { get; }
        public bool IsComputed { get; }
        public short? Size { get; }
        public byte? Precision { get; }
        public byte? Scale { get; }
        public IDictionary<string, string> Properties { get; }
        public SqlDbType SqlType { get; }

        public ColumnModel(ISqlEntityModel entity, MsSqlColumn column)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
            Properties = BuildColumnDocumentationMetadata(column ?? throw new ArgumentNullException(nameof(column)));
            Name = column.Name;
            IsNullable = column.IsNullable;
            IsIdentity = column.IsIdentity;
            IsComputed = column.IsComputed;
            Size = SupportsSize(column) ? column.MaxLength == 0 ? (short?)null : column.MaxLength : null;
            Precision = SupportsPrecision(column) ? column.Precision == 0 ? (byte?)null : column.Precision : null;
            Scale = SupportsPrecision(column) ? column.Scale == 0 ? (byte?)null : column.Scale : null;
            SqlType = column.SqlType;
        }

        public override string ToString()
            => $"[{Entity.Schema.Name}].[{Entity.Name}].[{Name}]";

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

        private bool SupportsSize(MsSqlColumn column)
        {
            switch (column.SqlType)
            {
                case SqlDbType.Binary:
                case SqlDbType.Char:
                case SqlDbType.DateTime2:
                case SqlDbType.DateTimeOffset:
                case SqlDbType.VarBinary:
                case SqlDbType.VarChar:
                case SqlDbType.NChar:
                case SqlDbType.NVarChar:
                case SqlDbType.Time:
                    return true;

                default:
                    return false;
            }
        }

        private bool SupportsPrecision(MsSqlColumn column)
        {
            switch (column.SqlType)
            {
                case SqlDbType.Decimal:
                    return true;

                default:
                    return false;
            }
        }
    }
}
