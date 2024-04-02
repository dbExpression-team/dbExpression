using DbExpression.CodeTemplating.Builder;
using DbExpression.CodeTemplating.Model;
using System.Linq;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class SoundexFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "Soundex";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel typeModel)
        {
            base.PopulateModel(model, @namespace, typeModel);
            model.FunctionName = functionName;

            model.Namespace = @namespace;
            model.Usings.Add("DbExpression.Sql.Expression");
            model.ArithmeticOperations = TypeBuilder.CreateBuilder().Add<string>().ToList().Select(@type => new ArithmeticOperationsTemplateModel
            {
                OperationType = @type,
                ReturnType = ArithmeticBuilder.InferReturnTypeByPrecedence(typeModel, @type),
                Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(typeModel, @type).ToList()
            }).ToList();
        }

        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var type in TypeBuilder.CreateBuilder().Add<string>().ToList())
                Generate(templatePath, outputSubdirectory, $"{type}{functionName}FunctionExpression.generated.cs", CreateModel("DbExpression.MsSql.Expression", type));
        }
    }
}
