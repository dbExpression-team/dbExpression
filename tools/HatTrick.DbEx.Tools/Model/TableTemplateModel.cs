using HatTrick.DbEx.Tools.Service;
using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Tools.Model
{
    public class TableTemplateModel : ISqlEntityModel
    {
        private readonly MsSqlTable _table;
        private readonly CodeGenerationHelpers _helpers;

        public string SchemaName => _table.GetParent().Name;
        public string Name => _helpers.ResolveName(_table);
        public string TypeName => "table";
        public EntityModel Entity { get; }
        public DocumentationPropertiesModel Documentation { get; }

        public TableTemplateModel(MsSqlTable table, CodeGenerationHelpers helpers)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
            _helpers = helpers ?? throw new ArgumentNullException(nameof(helpers));
            Entity = new EntityModel(table, helpers);
            Documentation = new DocumentationPropertiesModel(
                new Dictionary<string, string> { { "name", table.Name } },
                BuildIndexDocumentationMetadata(table)
            );
        }

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
