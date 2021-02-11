using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Executor
{
    public class Row : ISqlFieldReader
    {
        #region internals
        private int fieldIndex;
        private IList<ISqlField> fields;
        #endregion

        #region interface
        public int Index { get; private set; }
        public int FieldCount => fields.Count;
        public int CurrentFieldIndex => fieldIndex;
        #endregion

        #region constructors
        public Row(int index, IList<ISqlField> fields)
        {
            Index = index;
            this.fields = fields ?? throw new ArgumentNullException($"{nameof(fields)} is required.");
        }
        #endregion

        #region methods
        public ISqlField ReadField() => fieldIndex >= fields.Count ? null : fields[fieldIndex++];

        public T GetValue<T>(int index)
        {
            var field = fields[index];
            if (field.Value == default)
                return default;
            return field.GetValue<T>();
        }

        public IEnumerable<ISqlField> GetFields() => fields;
        #endregion
    }
}
