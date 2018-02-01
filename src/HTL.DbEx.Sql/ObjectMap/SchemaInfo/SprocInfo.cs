using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SprocInfo : EntityInfo
    {
        #region interface properties
        //public string Id { get; set; }
        //public string SchemaOwner { get; set; }
        //public string Name { get; set; }
        //public Dictionary<string, string> ExtendedProperties { get; set; }
        //public EntityType EntityType { get; set; }
        public bool IsStartupSproc { get; set; }
        public List<ParameterInfo> Parameters { get; set; }
        #endregion

        #region constructor
        public SprocInfo() : base()
        {
            this.Parameters = new List<ParameterInfo>();
        }
        #endregion
    }
}
