using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Executor
{
    public class Row : ISqlRow
    {
        #region internals
        private int fieldIndex;
        private IList<ISqlField> fields;
        #endregion

        #region interface
        public int Index { get; private set; }
        public int FieldCount => fields.Count;
        #endregion

        #region constructors
        public Row(int index, IList<ISqlField> fields)
        {
            Index = index;
            this.fields = fields;
        }
        #endregion

        #region methods
        public ISqlField ReadField() => fieldIndex >= fields.Count ? null : fields[fieldIndex++];

        public T GetValue<T>(int index)
            where T : IComparable
        {
            var field = fields[index];
            if (field.Value == default)
                return default;
            return (T)Convert.ChangeType(field.Value, typeof(T));
        }
        #endregion
    }
}
