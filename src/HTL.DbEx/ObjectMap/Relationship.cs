using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTL.DbEx.ObjectMap
{
    public abstract class Relationship
    {
        #region internals
        #endregion

        #region interface properties
        public virtual string Name { get; protected set; }

        public virtual string ReferencedEntity { get; protected set; }

        public virtual string ReferencedField { get; protected set; }

        public virtual string LocalEntity { get; protected set; }

        public virtual string LocalField { get; protected set; }
        #endregion

        #region constructors
        #endregion

        #region methods
        public override string ToString()
        {
            return this.Name + " As [" + this.LocalEntity + "].[" + this.LocalField + "] FK of [" + this.ReferencedEntity + "].[" + this.ReferencedField + "]";
        }
        #endregion
    }
}
