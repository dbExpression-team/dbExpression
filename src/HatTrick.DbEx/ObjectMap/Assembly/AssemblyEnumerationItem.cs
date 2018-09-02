using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using HatTrick.DbEx.Utility;

namespace HatTrick.DbEx.ObjectMap.Assembly
{
    public class AssemblyEnumerationItem : EnumerationItem
    {
        #region internals
        private FieldInfo _fieldInfo;
        #endregion

        #region interface properties
        #endregion

        #region constructors
        public AssemblyEnumerationItem(FieldInfo fieldInfo)
        {
            _fieldInfo = fieldInfo;
            this.ExtractItem();
        }
        #endregion

        #region methods
        private void ExtractItem()
        {
            base.Value = _fieldInfo.GetValue(_fieldInfo.ReflectedType);
            base.FriendlyName = string.Empty;
            base.AssemblyIntegralType = TypeUtility.GetUnderlyingEnumType(_fieldInfo.ReflectedType);
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
