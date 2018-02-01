using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTL.DbEx.Sql.ObjectMap
{
    public abstract class ColumnInfo
    {
        #region interface properties
        public string ParentObjectName { get; set; }
        public string ParentObjectId { get; set; }

        public virtual bool IsIdentity { get; set; }
        public virtual int? DefaultObjectId { get; set; }
        public virtual string DefaultValueDefinition { get; set; }

        public string ColumnName { get; set; }
        public int ColumnId { get; set; }
        public bool IsNullable { get; set; }
        public string DataType { get; set; }
        public int CharacterMaxLength { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }
        public bool IsComputed { get; set; }
        public bool UnSigned { get; set; }
        public int Ordinal { get; set; }
        public bool IsPrimaryKey { get; set; }
        public Dictionary<string, string> ExtendedProperties { get; set; }
        #endregion

        #region constructors
        public ColumnInfo()
        {
            this.ExtendedProperties = new Dictionary<string, string>();
        }
        #endregion

        #region methods
        #endregion
    }
}
