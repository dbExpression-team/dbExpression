using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.ObjectMap
{
    public abstract class Enumeration
    {
        #region interface properties
        //Namespace + [container] + name --> could be inside a class when extracted from an assembly
        public string Name { get; set; }

        public string FullyQualifiedName { get; set; } = string.Empty;

        public Type IntegralType { get; set; }

        public IList<EnumerationItem> Items { get; set; } = new List<EnumerationItem>();
        #endregion

        #region constructors
        #endregion

        #region methods
        public override string ToString() => Name;

        public void AddItem(EnumerationItem item) => Items.Add(item);
        #endregion
    }
}
