namespace HatTrick.DbEx.CodeTemplating.Model
{
    public class FunctionTemplateModel : TemplateModel
    {
        public string FunctionName { get; set; }
        public bool IsGroupBySupported { get; set; } = true;
    }
}
