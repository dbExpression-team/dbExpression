﻿using DbExpression.CodeTemplating.Builder;
using DbExpression.CodeTemplating.Model;
using System.Linq;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class NullableCeilingFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "Ceiling";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel typeModel)
        {
            base.PopulateModel(model, @namespace, typeModel);
            model.FunctionName = functionName;
            model.IsAggregateFunction = false;
            model.ArithmeticOperations = TypeBuilder.CreateBuilder().AddNumericTypes().ToList().Select(@type => new ArithmeticOperationsTemplateModel
            {
                OperationType = @type,
                ReturnType = @type,
                Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(typeModel, @type).ToList()
            }).ToList();
        }

        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var @type in TypeBuilder.CreateBuilder().AddNumericTypes().Add<object?>().ToList())
                Generate(templatePath, outputSubdirectory, $"Nullable{@type.Name}{functionName}FunctionExpression.generated.cs", CreateModel("DbExpression.Sql.Expression", @type));
        }
    }
}
