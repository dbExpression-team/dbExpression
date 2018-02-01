using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class ViewColumnInfo : ColumnInfo
    {
        #region internals
        #endregion

        #region interface
        public string ViewName 
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
        public string ViewId 
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

        public override bool IsIdentity 
        {
            get { return false; }
        }

        public override int? DefaultObjectId 
        {
            get { return null; }
        }
        public override string DefaultValueDefinition 
        {
            get { return null; }
        }
        #endregion

        #region constructors
        public ViewColumnInfo() : base() { }
        #endregion

        #region methods
        public override string ToString()
        {
            return "[" + this.ViewName + "].[" + base.ColumnName + "]";
        }
        #endregion
    }
}
