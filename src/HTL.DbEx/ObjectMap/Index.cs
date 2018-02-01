using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTL.DbEx.ObjectMap
{
    public abstract class Index
    {
        #region internals
        #endregion

        #region interface properties
        public virtual string EntityName { get; protected set; }
        public virtual bool IsComposite
        {
            get
            {
                return this.AffectedFields.Count > 1;
            }
        }
        public virtual List<IndexedField> AffectedFields { get; private set; }
        public virtual bool IsClustered { get; protected set; }
        public virtual bool IsUnique { get; protected set; }
        public virtual bool IsPrimaryKey { get; protected set; }
        public virtual string ModelRefKey { get; protected set; }
        #endregion

        #region constructors
        public Index()
        {
            this.AffectedFields = new List<IndexedField>();
        }
        #endregion

        #region methods
        protected void AddAffectedField(IndexedField idxField)
        {
            AffectedFields.Add(idxField);
        }
        #endregion
    }
}
