using HatTrick.Model.MsSql;
using System;

namespace HatTrick.DbEx.Tools.Model
{
    public class SchemaModel
    {
        public MsSqlModel Database { get; }
        public string Name { get; }

        public SchemaModel(MsSqlModel database, MsSqlSchema schema)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
            Name = schema?.Name ?? throw new ArgumentNullException(nameof(schema));
        }

        public override string ToString()
            => Name;
    }
}
