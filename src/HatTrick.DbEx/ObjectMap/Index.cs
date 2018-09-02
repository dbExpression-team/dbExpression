using System.Collections.Generic;

namespace HatTrick.DbEx.ObjectMap
{
    public abstract class Index
    {
        #region internals
        #endregion

        #region interface properties
        public virtual string Name { get; protected set; }
        public virtual string EntityName { get; protected set; }
        public virtual bool IsComposite
        {
            get
            {
                return this.AffectedFields.Count > 1;
            }
        }
        public virtual IList<IndexedField> AffectedFields { get; private set; } = new List<IndexedField>();
        public virtual bool IsClustered { get; protected set; }
        public virtual bool IsUnique { get; protected set; }
        public virtual bool IsPrimaryKey { get; protected set; }
        public virtual string ModelRefKey { get; protected set; }
        #endregion

        #region constructors
        #endregion

        #region methods
        protected void AddAffectedField(IndexedField idxField)
        {
            AffectedFields.Add(idxField);
        }
        #endregion
    }
}
