using DbExpression.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using DbExpression.CodeTemplating.Builder;

namespace DbExpression.CodeTemplating.CodeGenerator
{
    public class GetUtcDateFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "GetUtcDate";

        protected override FunctionTemplateModel CreateModel(string @namespace, TypeModel @type)
        {
            FunctionTemplateModel model = new()
            {
                Type = TypeBuilder.Get<DateTime>(),
                FunctionName = functionName
            };

            model.Namespace = @namespace;
            model.Usings.Add("DbExpression.Sql.Expression");
            model.ArithmeticOperations = new List<ArithmeticOperationsTemplateModel>()
            {
                new ArithmeticOperationsTemplateModel
                {
                    OperationType = TypeBuilder.Get<DateTime>(),
                    ReturnType = TypeBuilder.Get<DateTime>(),
                    Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(@type, TypeBuilder.Get<DateTime>()).ToList()
                }
            };
            model.Filters.ThisTypeOnlyFilters = new List<FilterOperationsTemplateModel>
            {
                new FilterOperationsTemplateModel
                {
                    Type = @type,
                    Operations = FilterBuilder.CreateBuilder().InferFilterOperations(@type, TypeBuilder.Get<DateTime>()).ToList()
                }
            };
            
            return model;
        }

        public override void Generate(string templatePath, string outputSubdirectory)
        {
            Generate(templatePath, outputSubdirectory, $"{functionName}FunctionExpression.generated.cs", CreateModel("DbExpression.MsSql.Expression", TypeBuilder.CreateBuilder().Add<DateTime>().ToList().Single()));
        }
    }
}
