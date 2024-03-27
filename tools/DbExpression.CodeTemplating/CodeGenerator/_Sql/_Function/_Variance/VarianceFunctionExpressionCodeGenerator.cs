using DbExpression.CodeTemplating.Builder;
using DbExpression.CodeTemplating.Model;
using System.Linq;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class VarianceFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "Variance";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel typeModel)
        {
            base.PopulateModel(model, @namespace, typeModel);
            model.FunctionName = functionName;
            model.IsAggregateFunction = true;
            model.ArithmeticOperations = TypeBuilder.CreateBuilder().AddNumericTypes().ToList().Select(@type => new ArithmeticOperationsTemplateModel
            {
                OperationType = @type,
                ReturnType = TypeBuilder.Get<float>(),
                Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(typeModel, @type).ToList()
            }).ToList();
        }

        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var @type in TypeBuilder.CreateBuilder().Add<float>().ToList())
                Generate(templatePath, outputSubdirectory, $"{@type.Name}{functionName}FunctionExpression.generated.cs", CreateModel("DbExpression.Sql.Expression", @type));
        }
    }
}
