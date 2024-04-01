namespace DbExpression.Tools.Model
{
    public class RuntimeModel
    {
        public RuntimeStrategy Strategy { get; set; }
        public string? AccessorName { get; set; }
        public bool IsStatic => Strategy == RuntimeStrategy.Static;

        public RuntimeModel(RuntimeStrategy strategy, string? accessorName)
        {
            Strategy = strategy;
            AccessorName = accessorName;
        }
    }
}
