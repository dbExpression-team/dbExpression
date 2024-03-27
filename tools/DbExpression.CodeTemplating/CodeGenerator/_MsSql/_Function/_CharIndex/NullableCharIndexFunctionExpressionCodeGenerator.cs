using DbExpression.CodeTemplating.Builder;
using DbExpression.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class NullableCharIndexFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "CharIndex";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel typeModel)
        {
            base.PopulateModel(model, @namespace, typeModel);
            model.FunctionName = functionName;

            model.Namespace = @namespace;
            model.Usings.Add("DbExpression.Sql.Expression");
            model.ArithmeticOperations = TypeBuilder.CreateBuilder().AddNumericTypes().ToList().Select(@type => new ArithmeticOperationsTemplateModel
            {
                OperationType = @type,
                ReturnType = ArithmeticBuilder.InferReturnTypeByPrecedence(typeModel, @type),
                Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(typeModel, @type).ToList()
            }).ToList();
        }

        public override void Generate(string templatePath, string outputSubdirectory)
            => Generate(templatePath, outputSubdirectory, $"Nullable{TypeBuilder.Get<long>()}{functionName}FunctionExpression.generated.cs", CreateModel("DbExpression.MsSql.Expression", TypeBuilder.Get<long>()));
    }
}
