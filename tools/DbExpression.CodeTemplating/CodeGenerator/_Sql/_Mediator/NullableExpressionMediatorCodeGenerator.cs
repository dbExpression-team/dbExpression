using DbExpression.CodeTemplating.Builder;
using DbExpression.CodeTemplating.Model;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class NullableExpressionMediatorCodeGenerator : CodeGenerator<TemplateModel>
    {
        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var @type in TypeBuilder.CreateBuilder().AddAllTypes().Add<object?>().ToList())
                Generate(templatePath, outputSubdirectory, $"Nullable{@type.Name}ExpressionMediator.generated.cs", CreateModel("DbExpression.Sql.Expression", @type));
        }
    }
}
