using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Tools.Model
{
	public class StoredProcedureModel
	{
		public SchemaModel Schema { get; }
		public string Name { get; }

        public StoredProcedureModel(SchemaModel schema, MsSqlProcedure procedure)
        {
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));
            Name = procedure?.Name ?? throw new ArgumentNullException(nameof(procedure));
        }

        public override string ToString() => $"[{Schema.Name}].[{Name}]";
    }
}
