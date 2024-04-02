using DbExpression.CodeTemplating.Builder;
using DbExpression.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class ExpressionMediatorCodeGenerator : CodeGenerator<TemplateModel>
    {
        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var @type in TypeBuilder.CreateBuilder().AddAllTypes().ToList())
                Generate(templatePath, outputSubdirectory, $"{@type.Name}ExpressionMediator.generated.cs", CreateModel("DbExpression.Sql.Expression", @type));
        }
    }
}
