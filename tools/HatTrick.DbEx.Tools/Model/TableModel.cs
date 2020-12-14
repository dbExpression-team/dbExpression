using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Tools.Model
{
    public class TableModel : ISqlEntityModel
    {
        public SchemaModel Schema { get; }
        public string Name { get; }
        public string TypeIdentifier => "table";
        public IDictionary<string, string> Properties { get; }
        public IList<(string, IDictionary<string, string>)> Indexes { get; }

        public TableModel(SchemaModel schema, MsSqlTable table)
        {
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));
            Name = table?.Name ?? throw new ArgumentNullException(nameof(schema));
            Properties = new Dictionary<string, string> { { "name", table.Name } };
            Indexes = BuildIndexDocumentationMetadata(table).ToList();
        }

        public override string ToString()
            => $"[{Schema.Name}].[{Name}]";

        private IEnumerable<(string, IDictionary<string, string>)> BuildIndexDocumentationMetadata(INamedMeta meta)
        {
            if (meta is MsSqlTable table)
            {
                foreach (var index in table.Indexes)
                {
                    var attributes = new Dictionary<string, string>();
                    if (index.Value.IsPrimaryKey)
                        attributes.Add("primary key", "yes");
                    attributes.Add("columns", index.Value.IndexedColumns.Aggregate(string.Empty, (s, column) => $"{s}{column.ColumnName}{(column != index.Value.IndexedColumns.Last() ? ", " : string.Empty)}"));

                    yield return (index.Key, attributes);
                }
            }
            yield break;
        }        
    }
}
