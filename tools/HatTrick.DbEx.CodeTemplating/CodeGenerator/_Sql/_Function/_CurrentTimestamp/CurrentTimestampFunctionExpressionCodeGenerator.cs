using HatTrick.DbEx.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using HatTrick.DbEx.CodeTemplating.Builder;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class CurrentTimestampFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "CurrentTimestamp";

        protected override FunctionTemplateModel CreateModel(string @namespace, TypeModel @type)
        {
            var model = new FunctionTemplateModel();
            model.Type = TypeBuilder.Get<DateTime>();
            model.FunctionName = functionName;

            model.Namespace = @namespace;
            model.ArithmeticOperations = new List<ArithmeticOperationsTemplateModel>
            {
                new ArithmeticOperationsTemplateModel
                {
                    OperationType = TypeBuilder.Get<DateTime>(),
                    ReturnType = TypeBuilder.Get<DateTime>(),
                    Operations = ArithmeticBuilder.CreateBuilder().AddArithmeticAdd().ToList()
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
            Generate(templatePath, outputSubdirectory, $"{functionName}FunctionExpression.generated.cs", CreateModel("HatTrick.DbEx.Sql.Expression", TypeBuilder.CreateBuilder().Add<DateTime>().ToList().Single()));
        }
    }
}
