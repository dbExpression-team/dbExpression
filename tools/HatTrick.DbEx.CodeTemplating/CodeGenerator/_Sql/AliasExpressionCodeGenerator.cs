using HatTrick.DbEx.CodeTemplating.Builder;
using HatTrick.DbEx.CodeTemplating.Model;
using System.Linq;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class AliasExpressionCodeGenerator : CodeGenerator<TemplateModel>
    {
        protected override void PopulateModel(TemplateModel model, string @namespace, TypeModel typeModel)
        {
            base.PopulateModel(model, @namespace, typeModel);
            model.ArithmeticOperations = TypeBuilder.CreateBuilder().AddAllTypes().Except<object>().ToList().Select(@type => new ArithmeticOperationsTemplateModel
            {
                OperationType = @type,
                ReturnType = ArithmeticBuilder.InferReturnTypeByPrecedence(typeModel, @type),
                Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(typeModel, @type).ToList()
            }).ToList();
            
            model.Filters = TypeBuilder.CreateBuilder().AddAllTypes().ToList().Select(@type => new FilterOperationsTemplateModel
            {
                Type = @type,
                Operations = FilterBuilder.CreateBuilder().InferFilterOperations(typeModel, @type).ToList()
            }).ToList();
        }

        public override void Generate(string templatePath, string outputSubdirectory)
        {
            Generate(templatePath, outputSubdirectory, $"AliasExpression.generated.cs", CreateModel("HatTrick.DbEx.Sql.Expression", TypeBuilder.Create<object>()));
        }
    }
}
