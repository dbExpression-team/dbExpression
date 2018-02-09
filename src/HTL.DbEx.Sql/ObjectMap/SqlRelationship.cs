using System;
using System.Collections.Generic;
using HTL.DbEx.ObjectMap;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SqlRelationship : Relationship
    {
        #region ineterface properties
        public string ReferencedEntityId { get; set; }

        public string LocalEntityId { get; set; }
        #endregion
    }
}
