using DbExpression.CodeTemplating.Builder;
using DbExpression.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class NullableFieldExpressionCodeGenerator : CodeGenerator<TemplateModel>
    {
        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var @type in TypeBuilder.CreateBuilder().AddAllTypes().Except<object>().Add<string?>().ToList())
                Generate(templatePath, outputSubdirectory, $"Nullable{@type.Name}FieldExpression.generated.cs", CreateModel("DbExpression.Sql.Expression", @type));
        }
    }
}
