using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using HTL.DbEx.ObjectMap;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SqlRelationship : Relationship
    {
        #region internals
        #endregion

        #region ineterface properties
        public new string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        public string ReferencedEntityId //referenced table id
        {
            get;
            set;
        }

        public new string ReferencedEntity
        {
            get
            {
                return base.ReferencedEntity;
            }
            set
            {
                base.ReferencedEntity = value;
            }
        }

        public  new string ReferencedField
        {
            get
            {
                return base.ReferencedField;
            }
            set
            {
                base.ReferencedField = value;
            }
        }

        public string LocalEntityId //local table id
        {
            get;
            set;
        }

        public new string LocalEntity
        {
            get
            {
                return base.LocalEntity;
            }
            set
            {
                base.LocalEntity = value;
            }
        }

        public new string LocalField
        {
            get
            {
                return base.LocalField;
            }
            set
            {
                base.LocalField = value;
            }
        }
        #endregion

        #region constructors
        #endregion

        #region methods
        #endregion
    }
}
