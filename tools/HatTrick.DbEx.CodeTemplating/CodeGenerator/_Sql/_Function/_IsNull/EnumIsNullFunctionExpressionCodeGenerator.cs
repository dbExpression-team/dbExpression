using HatTrick.DbEx.CodeTemplating.Builder;
using HatTrick.DbEx.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class EnumIsNullFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "IsNull";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel typeModel)
        {
            model.FunctionName = functionName;
            model.Namespace = @namespace;
            model.Type = typeModel;
            model.IsOrderBySupported = true;
            model.IsGroupBySupported = true;
            model.FilterOperations = FilterBuilder.CreateBuilder().AddEqual().AddNotEqual().ToList();
        }

        public override void Generate(string templatePath, string outputSubdirectory)
            => Generate(templatePath, outputSubdirectory, $"Enum{functionName}FunctionExpression.generated.cs", CreateModel("HatTrick.DbEx.Sql.Expression", null));
    }
}
