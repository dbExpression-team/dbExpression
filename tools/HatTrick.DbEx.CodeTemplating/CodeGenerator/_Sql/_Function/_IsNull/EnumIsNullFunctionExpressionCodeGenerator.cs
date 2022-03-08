﻿using HatTrick.DbEx.CodeTemplating.Model;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class EnumIsNullFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "IsNull";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel? typeModel)
        {
            model.FunctionName = functionName;
            model.Namespace = @namespace;
            if (typeModel is not null)
                model.Type = typeModel;
            model.IsAggregateFunction = false;
        }

        public override void Generate(string templatePath, string outputSubdirectory)
            => Generate(templatePath, outputSubdirectory, $"Enum{functionName}FunctionExpression.generated.cs", CreateModel("HatTrick.DbEx.Sql.Expression", null!));
    }
}
