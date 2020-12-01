using HatTrick.DbEx.CodeTemplating.Builder;
using HatTrick.DbEx.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class NullableFieldExpressionCodeGenerator : CodeGenerator<TemplateModel>
    {
        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var @type in TypeBuilder.CreateBuilder().AddAllTypes().Except<object>().ToList())
                Generate(templatePath, outputSubdirectory, $"Nullable{@type.Name}FieldExpression.generated.cs", CreateModel("HatTrick.DbEx.Sql.Expression", @type));
        }
    }
}
