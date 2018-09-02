using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.ObjectMap
{
    public class TableColumnInfo : ColumnInfo
    {
        #region internals
       
        #endregion

        #region interface
        public string TableName 
        {
            get
            {
                return base.ParentObjectName;
            }
            set
            {
                base.ParentObjectName = value;
            }
        }
        public string TableId 
        {
            get
            {
                return base.ParentObjectId;
            }
            set
            {
                base.ParentObjectId = value;
            }
        }
        #endregion

        #region constructors
        public TableColumnInfo() : base() { }
        #endregion

        #region methods
        public override string ToString()
        {
            return this.TableName + "." + base.ColumnName;
        }
        #endregion
    }
}
