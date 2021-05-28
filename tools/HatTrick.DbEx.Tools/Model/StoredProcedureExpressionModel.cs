using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Tools.Model
{
	public class StoredProcedureExpressionModel
	{
        public SchemaExpressionModel SchemaExpression { get; }
        public string Name { get; }

        public StoredProcedureExpressionModel(SchemaExpressionModel schemaExpression, string name)
        {
            SchemaExpression = schemaExpression;
            Name = name;
        }

        public override string ToString() => $"{Name}Procedure";
    }
}
