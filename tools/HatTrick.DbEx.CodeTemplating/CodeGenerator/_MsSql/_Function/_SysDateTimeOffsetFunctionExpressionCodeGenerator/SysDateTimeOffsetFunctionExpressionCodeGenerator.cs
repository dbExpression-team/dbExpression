using HatTrick.DbEx.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using HatTrick.DbEx.CodeTemplating.Builder;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class SysDateTimeOffsetFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "SysDateTimeOffset";

        protected override FunctionTemplateModel CreateModel(string @namespace, TypeModel @type)
        {
            var model = new FunctionTemplateModel();
            model.Type = TypeBuilder.Get<DateTimeOffset>();
            model.FunctionName = functionName;

            model.Namespace = @namespace;
            model.Usings.Add("HatTrick.DbEx.Sql.Expression");
            model.ArithmeticOperations = new List<ArithmeticOperationsTemplateModel>()
            {
                new ArithmeticOperationsTemplateModel
                {
                    OperationType = TypeBuilder.Get<DateTimeOffset>(),
                    ReturnType = TypeBuilder.Get<DateTimeOffset>(),
                    Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(@type, TypeBuilder.Get<DateTime>()).ToList()
                }
            };
            model.Filters = new List<FilterOperationsTemplateModel>
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
            Generate(templatePath, outputSubdirectory, $"{functionName}FunctionExpression.generated.cs", CreateModel("HatTrick.DbEx.MsSql.Expression", TypeBuilder.CreateBuilder().Add<DateTimeOffset>().ToList().Single()));
        }
    }
}
