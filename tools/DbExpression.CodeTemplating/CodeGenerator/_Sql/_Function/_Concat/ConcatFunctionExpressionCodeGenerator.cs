using DbExpression.CodeTemplating.Builder;
using DbExpression.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class ConcatFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "Concat";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel typeModel)
        {
            base.PopulateModel(model, @namespace, typeModel);
            model.FunctionName = functionName;
            model.ArithmeticOperations = TypeBuilder.CreateBuilder().Add<string>().ToList().Select(@type => new ArithmeticOperationsTemplateModel
            {
                OperationType = @type,
                ReturnType = typeModel,
                Operations = ArithmeticBuilder.CreateBuilder().AddArithmeticAdd().ToList()
            }).ToList();
        }

        public override void Generate(string templatePath, string outputSubdirectory)
            => Generate(templatePath, outputSubdirectory, $"{TypeBuilder.Get<string>().Name}{functionName}FunctionExpression.generated.cs", CreateModel("DbExpression.Sql.Expression", TypeBuilder.Get<string>()));
    }
}
