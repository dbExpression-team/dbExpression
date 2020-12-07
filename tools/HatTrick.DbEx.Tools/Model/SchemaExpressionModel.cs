using HatTrick.Model.MsSql;
using System;

namespace HatTrick.DbEx.Tools.Model
{
    public class SchemaExpressionModel
    {
        public DatabaseExpressionModel DatabaseExpression { get; }
        public string NamespaceRoot { get; }
        public string Name { get; }
        public bool IsIgnored { get; }

        public SchemaExpressionModel(DatabaseExpressionModel database, MsSqlSchema schema, string namespaceRoot, string name, bool isIgnored)
        {
            DatabaseExpression = database ?? throw new ArgumentNullException(nameof(database));
            Name = name;
            NamespaceRoot = namespaceRoot;
            IsIgnored = isIgnored;
        }
    }
}
