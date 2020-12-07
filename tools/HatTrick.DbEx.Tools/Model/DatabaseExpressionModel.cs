namespace HatTrick.DbEx.Tools.Model
{
    public class DatabaseExpressionModel
    {
        public string NamespaceRoot { get; }
        public string Name { get; }
        public bool IsIgnored { get; }

        public DatabaseExpressionModel(string name, bool isIgnored, string namespaceRoot)
        {
            Name = name;
            IsIgnored = isIgnored;
            NamespaceRoot = namespaceRoot;
        }
    }
}
