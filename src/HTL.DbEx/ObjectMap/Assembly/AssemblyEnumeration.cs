using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using HTL.DbEx.Utility;

namespace HTL.DbEx.ObjectMap.Assembly
{
    public class AssemblyEnumeration : Enumeration
    {
        #region internals
        private Type _type;
        #endregion

        #region interface properties
        #endregion

        #region constructors
        public AssemblyEnumeration(Type t)
        {
            _type = t;
            this.ExtractEnumeration();
        }
        #endregion

        #region methods
        private void ExtractEnumeration()
        {
            base.Name = _type.Name;
            base.FullyQualifiedName = _type.FullName;
            base.IntegralType = TypeUtility.GetUnderlyingEnumType(_type);

            FieldInfo[] fields = _type.GetFields();

            foreach (FieldInfo f in fields)
            {
                if (f.Name == "value__") { continue; }
                AssemblyEnumerationItem aei = new AssemblyEnumerationItem(f);
                base.AddItem(aei);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
