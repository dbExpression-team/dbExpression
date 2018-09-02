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
            public IList<(int, string, object)> Fields { get; } = new List<(int, string, object)>();

            public Row() { }

            public Row((int, string, object) field)
            {
                Fields.Add(field);
            }

            public Row(IList<(int, string, object)> fields)
            {
                Fields = fields;
            }

            public T GetValue<T>(int index)
            {
                var field = Fields.FirstOrDefault(f => f.Item1 == index);
                if (Equals(field, default((int, string, object))))
                    throw new IndexOutOfRangeException();
                if (Equals(field.Item3, default(T)))
                    return default(T);
                return (T)Convert.ChangeType(field.Item3, typeof(T));
            }
        }
    }
}
