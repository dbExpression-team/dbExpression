using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SqlStatementExecutionResultSet
    {
        public IList<Row> Rows { get; } = new List<Row>();

        public bool HasData() => Rows.Any() && Rows[0].Fields.Any();

        public class Row : IFieldReader
        {
            private int readIndex;

            public IDictionary<int, Field> Fields { get; } = new Dictionary<int, Field>();

            public Row() { }

            public Row(int index, Field field)
            {
                Fields.Add(index, field);
            }

            public Row(IList<(int, string, object)> fields)
            {
                Fields = fields.ToDictionary(f => f.Item1, f => new Field(f.Item2, f.Item3));
            }

            public T GetValue<T>(int index)
                where T : IComparable
            {
                var field = Fields[index];
                if (field.Value == default)
                    return default;
                return (T)Convert.ChangeType(field.Value, typeof(T));
            }

            public object Read() => Fields[readIndex++].Value;
        }

        public class Field
        {
            public string Name { get; set; }
            public object Value { get; set; }

            public Field(string name, object value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}
