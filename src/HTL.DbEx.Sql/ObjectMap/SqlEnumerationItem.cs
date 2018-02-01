using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTL.DbEx.ObjectMap;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SqlEnumerationItem : EnumerationItem
    {
        #region internals
        protected TypeCodeItemInfo _itemInfo; 
        #endregion

        #region interface
        #endregion

        #region constructors
        public SqlEnumerationItem(TypeCodeItemInfo typeCodeItem)
        {
            _itemInfo = typeCodeItem;
            this.ExtractEnumerationItem();
        }
        #endregion

        #region methods
        private void ExtractEnumerationItem()
        {
            base.Key = _itemInfo.Key;
            base.Value = _itemInfo.Value;
            base.FriendlyName = _itemInfo.FriendlyName;
            base.Description = _itemInfo.Description;
            base.AssemblyIntegralType = typeof(int);
        }
        #endregion
    }
}
