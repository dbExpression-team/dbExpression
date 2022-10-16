using HatTrick.DbEx.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using HatTrick.DbEx.CodeTemplating.Builder;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class NewIdFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "NewId";

        protected override FunctionTemplateModel CreateModel(string @namespace, TypeModel @type)
        {
            FunctionTemplateModel model = new()
            {
                Type = TypeBuilder.Get<Guid>(),
                FunctionName = functionName
            };
            model.Namespace = @namespace;
            model.Usings.Add("HatTrick.DbEx.Sql.Expression");
            model.ArithmeticOperations = new List<ArithmeticOperationsTemplateModel>();
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
            Generate(templatePath, outputSubdirectory, $"{functionName}FunctionExpression.generated.cs", CreateModel("HatTrick.DbEx.MsSql.Expression", TypeBuilder.CreateBuilder().Add<Guid>().ToList().Single()));
        }
    }
}
