using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SqlStatementExecutionResultSet
    {
        public IList<Row> Rows { get; } = new List<Row>();

        public bool HasData() => Rows.Any() && Rows[0].Fields.Any();

        public class Row
        {
            public IDictionary<int, (string, object)> Fields { get; } = new Dictionary<int, (string, object)>();

            public Row() { }

            public Row((int, string, object) field)
            {
                Fields.Add(field.Item1, (field.Item2, field.Item3));
            }

            public Row(IList<(int, string, object)> fields)
            {
                Fields = fields.ToDictionary(f => f.Item1, f => (f.Item2, f.Item3));
            }

            public T GetValue<T>(int index)
            {
                var field = Fields[index];
                if (field == default)
                    throw new IndexOutOfRangeException();
                if (field.Item2 == default)
                    return default;
                return (T)Convert.ChangeType(field.Item2, typeof(T));
            }
        }
    }
}
