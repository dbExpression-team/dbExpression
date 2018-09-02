using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.DbEx.Sql.ObjectMap
{
    public class EntityInfo
    {
        #region interface properties
        public string Id { get; set; }
        public string SchemaOwner { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> ExtendedProperties { get; set; }
        public EntityType EntityType { get; set; }
        #endregion

        #region constructors
        public EntityInfo()
        {
            this.ExtendedProperties = new Dictionary<string, string>();
        }
        #endregion

        #region methods
        public override string ToString()
        {
            return this.SchemaOwner + "." + this.Name;
        }
        #endregion
    }

    #region enums
    public enum EntityType
    {
        Unknown,
        Table,
        View,
        Sproc
    }
    #endregion
}
