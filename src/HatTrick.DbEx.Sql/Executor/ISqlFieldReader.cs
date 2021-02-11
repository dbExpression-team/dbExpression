using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlFieldReader
    {
        /// <summary>
        /// Get a rowset field and increments the current field index.  The next call to this method would return the next field in the rowset.
        /// </summary>
        /// <returns>An <see cref="ISqlField"/> containing the retrieved value and metadata for the field.</returns>
        ISqlField ReadField();

        /// <summary>
        /// Get a rowset field at the provided index.
        /// </summary>
        /// <returns>The <see cref="ISqlField"/> value of the field converted to <typeparamref name="T"/>.</returns>
        T GetValue<T>(int index);

        /// <summary>
        /// Get all fields from the rowset.  This method does NOT increment the current index of the reader.
        /// </summary>
        /// <returns>An enumerable of <see cref="ISqlField"/>s.</returns>
        IEnumerable<ISqlField> GetFields();

        /// <summary>
        /// Gets the total number of fields in the rowset.
        /// </summary>
        int FieldCount { get; }

        /// <summary>
        /// Gets the current index of the reader.  The index value is incremented only through a call to the <see cref="ReadField"/> method.
        /// </summary>
        int CurrentFieldIndex { get; }
    }
}
