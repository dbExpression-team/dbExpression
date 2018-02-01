using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class TypeCodeInfo
    {
        public string Name { get; set; }
        private List<TypeCodeItemInfo> _typeCodeItems;
        public List<TypeCodeItemInfo> TypeCodeItems
        {
            get { return _typeCodeItems; }
            set { _typeCodeItems = value; }
        }

        public TypeCodeInfo()
        { _typeCodeItems = new List<TypeCodeItemInfo>(); }
    }

    public class TypeCodeItemInfo
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string FriendlyName { get; set; }
        public string Description { get; set; }
    }
}
