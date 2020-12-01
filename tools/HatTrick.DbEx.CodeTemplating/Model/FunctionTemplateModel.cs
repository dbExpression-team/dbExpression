namespace HatTrick.DbEx.CodeTemplating.Model
{
    public class FunctionTemplateModel : TemplateModel
    {
        public string FunctionName { get; set; }
        public bool IsAggregateFunction { get; set; } = false;
    }
}
