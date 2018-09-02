using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.DbEx.Sql.ObjectMap
{
    public class IndexInfo
    {
        #region interface properties
        public string IndexName { get; set; }
        public string IndexId { get; set; }
        public string TableName { get; set; }
        public string TableId { get; set; }
        public string ColumnName { get; set; }
        public int ColumnId { get; set; }
        public byte IndexTypeCode { get; set; }
        public bool IsUnique { get; set; }
        public bool IsDescendingKey { get; set; }
        public byte ColumnOrdinal { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsIncludeColumn { get; set; }

        #endregion

        #region methods
        public override string ToString()
        {
            return "[" + this.TableName + "].[" + this.ColumnName + "] As " + this.IndexName;
        }
        #endregion
    }
}
