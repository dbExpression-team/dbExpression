﻿using HatTrick.DbEx.CodeTemplating.Builder;
using HatTrick.DbEx.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class MaximumFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "Maximum";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel typeModel)
        {
            base.PopulateModel(model, @namespace, typeModel);
            model.FunctionName = functionName;
            model.IsAggregateFunction = true;
            model.ArithmeticOperations = TypeBuilder.CreateBuilder().AddNumericTypes().ToList().Select(@type => new ArithmeticOperationsTemplateModel
            {
                OperationType = @type,
                ReturnType = TypeBuilder.InferReturnType(typeModel, @type),
                Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(typeModel, @type).ToList()
            }).ToList();
        }

        public override void Generate(string templatePath, string outputSubdirectory)
        {
            foreach (var @type in TypeBuilder.CreateBuilder().AddAllTypes().Except<bool>().ToList())
                Generate(templatePath, outputSubdirectory, $"{@type.Name}{functionName}FunctionExpression.generated.cs", CreateModel("HatTrick.DbEx.Sql.Expression", @type));
        }
    }
}
