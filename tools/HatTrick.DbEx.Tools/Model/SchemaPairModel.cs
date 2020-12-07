using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Tools.Model
{
    public class SchemaPairModel
    { 
        public SchemaModel Schema { get; }
        public SchemaExpressionModel SchemaExpression { get; }
        public IList<EntityPairModel> Items { get; } = new List<EntityPairModel>();

        public SchemaPairModel(SchemaModel schema, SchemaExpressionModel schemaExpression)
        {
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));
            SchemaExpression = schemaExpression ?? throw new ArgumentNullException(nameof(schemaExpression));
        }
    }
}
