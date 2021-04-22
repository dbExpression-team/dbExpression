using HatTrick.DbEx.CodeTemplating.Builder;
using HatTrick.DbEx.CodeTemplating.Model;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class NullableExpressionMediatorCodeGenerator : CodeGenerator<TemplateModel>
    {
        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var @type in TypeBuilder.CreateBuilder().AddAllTypes().Except<object>().ToList())
                Generate(templatePath, outputSubdirectory, $"Nullable{@type.Name}ExpressionMediator.generated.cs", CreateModel("HatTrick.DbEx.Sql.Expression", @type));
        }
    }
}
