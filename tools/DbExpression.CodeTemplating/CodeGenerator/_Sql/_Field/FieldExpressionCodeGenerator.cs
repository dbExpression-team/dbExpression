using DbExpression.CodeTemplating.Builder;
using DbExpression.CodeTemplating.Model;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class FieldExpressionCodeGenerator : CodeGenerator<TemplateModel>
    {
        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var @type in TypeBuilder.CreateBuilder().AddAllTypes().Except<object>().ToList())
                Generate(templatePath, outputSubdirectory, $"{@type.Name}FieldExpression.generated.cs", CreateModel("DbExpression.Sql.Expression", @type));
        }
    }
}
