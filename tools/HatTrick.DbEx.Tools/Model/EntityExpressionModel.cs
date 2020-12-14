using System.Collections.Generic;

namespace HatTrick.DbEx.Tools.Model
{
    public class EntityExpressionModel
    {
        public SchemaExpressionModel SchemaExpression { get; }
        public string NamespaceRoot => SchemaExpression.NamespaceRoot;
        public string Name { get; }
        public IEnumerable<string> AppliedInterfaces { get; }

        public EntityExpressionModel(SchemaExpressionModel schemaExpression, string name, IList<string> interfaces)
        {
            SchemaExpression = schemaExpression;
            Name = name;
            AppliedInterfaces = interfaces;
        }

        public override string ToString()
            => $"{Name}Entity";
    }
}
