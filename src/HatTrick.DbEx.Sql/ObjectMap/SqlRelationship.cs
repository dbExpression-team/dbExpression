using System;
using System.Collections.Generic;
using HatTrick.DbEx.ObjectMap;

namespace HatTrick.DbEx.Sql.ObjectMap
{
    public class SqlRelationship : Relationship
    {
        #region ineterface properties
        public string ReferencedEntityId { get; set; }

        public string LocalEntityId { get; set; }
        #endregion
    }
}
