using HatTrick.DbEx.CodeTemplating.Builder;
using HatTrick.DbEx.CodeTemplating.Model;
using System.Linq;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class RoundFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "Round";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel typeModel)
        {
            base.PopulateModel(model, @namespace, typeModel);
            model.FunctionName = functionName;

            model.Namespace = @namespace;
            model.Usings.Add("HatTrick.DbEx.Sql.Expression");
            model.ArithmeticOperations = TypeBuilder.CreateBuilder().AddNumericTypes().ToList().Select(@type => new ArithmeticOperationsTemplateModel
            {
                OperationType = @type,
                ReturnType = ArithmeticBuilder.InferReturnTypeByPrecedence(typeModel, @type),
                Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(typeModel, @type).ToList()
            }).ToList();
        }

        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var @type in TypeBuilder.CreateBuilder().AddNumericTypes().Add<object>().Except(typeof(byte)).ToList())
                Generate(templatePath, outputSubdirectory, $"{@type.Name}{functionName}FunctionExpression.generated.cs", CreateModel("HatTrick.DbEx.MsSql.Expression", @type));
        }
    }
}
