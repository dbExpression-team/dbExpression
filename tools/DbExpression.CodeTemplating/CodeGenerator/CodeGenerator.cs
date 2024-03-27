using DbExpression.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class CodeGenerator
    {
        public CodeGenerator Generate<TGenerator, TModel>(string templatePath, string outputSubdirectory)
            where TGenerator : CodeGenerator<TModel>, new()
            where TModel : TemplateModel, new()
        {
            var generator = new TGenerator();
            generator.Generate(templatePath, outputSubdirectory);
            return this;
        }

        public static CodeGenerator CreateGenerator() => new CodeGenerator();
    }
}
