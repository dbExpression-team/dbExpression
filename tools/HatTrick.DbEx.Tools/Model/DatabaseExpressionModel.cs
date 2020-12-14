namespace HatTrick.DbEx.Tools.Model
{
    public class DatabaseExpressionModel
    {
        public string NamespaceRoot { get; }
        public string Name { get; }

        public DatabaseExpressionModel(string name, string namespaceRoot)
        {
            Name = name;
            NamespaceRoot = namespaceRoot;
        }

        public override string ToString()
            => Name;
    }
}
