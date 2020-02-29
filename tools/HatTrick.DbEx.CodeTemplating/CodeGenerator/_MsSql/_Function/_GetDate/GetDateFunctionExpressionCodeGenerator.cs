using HatTrick.DbEx.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using HatTrick.DbEx.CodeTemplating.Builder;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class GetDateFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "GetDate";

        protected override FunctionTemplateModel CreateModel(string @namespace, TypeModel @type)
        {
            var model = new FunctionTemplateModel();
            model.Type = TypeBuilder.Get<DateTime>();
            model.FunctionName = functionName;

            model.Namespace = @namespace;
            model.Usings.Add("HatTrick.DbEx.Sql.Expression");
            model.ArithmeticOperations = new List<ArithmeticOperationsTemplateModel>()
            {
                new ArithmeticOperationsTemplateModel
                {
                    OperationType = TypeBuilder.Get<DateTime>(),
                    ReturnType = TypeBuilder.Get<DateTime>(),
                    Operations = ArithmeticBuilder.CreateBuilder().AddArithmeticAdd().ToList()
                }
            };
            model.FilterOperations = FilterBuilder.CreateBuilder().AddAll().ToList();
            return model;
        }

        public override void Generate(string templatePath, string outputSubdirectory)
        {
            Generate(templatePath, outputSubdirectory, $"{functionName}FunctionExpression.generated.cs", CreateModel("HatTrick.DbEx.MsSql.Expression", TypeBuilder.CreateBuilder().Add<DateTime>().ToList().Single()));
        }
    }
}
