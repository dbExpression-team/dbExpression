using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class ParameterInfo
    {
        #region interface
        public string ParentObjectName { get; set; }
        public string ParentObjectId { get; set; }
        public string Name { get; set; }
        public int ParameterId { get; set; }
        //public bool IsNullable { get; set; }
        public string DataType { get; set; }
        public int MaxLength { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }
        public bool IsOutputParameter { get; set; }
        public Dictionary<string, string> ExtendedProperties { get; set; }
        #endregion

        #region constructors
        public ParameterInfo()
        {
            this.ExtendedProperties = new Dictionary<string, string>();
        }
        #endregion
    }
}
