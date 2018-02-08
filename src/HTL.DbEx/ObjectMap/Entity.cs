using System.Collections.Generic;

namespace HTL.DbEx.ObjectMap
{
    public abstract class Entity
    {
        #region interface properties
        public string Schema { get; set; }

        public string Name { get; set; }

        public bool IsIgnored { get; set; }

        public IList<Field> Fields { get; set; } = new List<Field>();

        public IList<Index> Indexes { get; set; } = new List<Index>();
        #endregion

        #region methods
        public void AddField(Field field) => Fields.Add(field);

        public void AddIndex(Index idx) => Indexes.Add(idx);

        public override string ToString() => Name;
        #endregion
    }
}
