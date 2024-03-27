using DbExpression.CodeTemplating.Model;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class EnumCoalesceFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "Coalesce";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel? typeModel)
        {
            model.FunctionName = functionName;
            model.Namespace = @namespace;
            if (typeModel is not null)
                model.Type = typeModel;
            model.IsAggregateFunction = false;
        }

        public override void Generate(string templatePath, string outputSubdirectory)
            => Generate(templatePath, outputSubdirectory, $"Enum{functionName}FunctionExpression.generated.cs", CreateModel("DbExpression.Sql.Expression", null!));
    }
}
