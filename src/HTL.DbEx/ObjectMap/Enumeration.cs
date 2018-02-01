using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTL.DbEx.ObjectMap
{
    public abstract class Enumeration
    {
        #region internals
        private string _name;
        //Namespace + [container] + name --> could be inside a class when extracted from an assembly
        private string _fullyQualifiedName;
        private Type _assemblyIntegralType;
        private List<EnumerationItem> _items = new List<EnumerationItem>();
        #endregion

        #region interface properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string FullyQualifiedName
        {
            get { return (string.IsNullOrEmpty(_fullyQualifiedName)) ? string.Empty : _fullyQualifiedName; }
            set { _fullyQualifiedName = value; }
        }

        public Type IntegralType
        {
            get { return _assemblyIntegralType; }
            set { _assemblyIntegralType = value; }
        }

        public List<EnumerationItem> Items
        {
            get { return _items; }
        }
        #endregion

        #region constructors
        #endregion

        #region methods
        public override string ToString()
        {
            return _name;
        }

        public void AddItem(EnumerationItem item)
        {
            _items.Add(item);
        }
        #endregion
    }
}
