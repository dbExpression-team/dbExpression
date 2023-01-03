using HatTrick.DbEx.CodeTemplating.Builder;
using HatTrick.DbEx.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class NullableSoundexFunctionExpressionCodeGenerator : CodeGenerator<FunctionTemplateModel>
    {
        private const string functionName = "Soundex";

        protected override void PopulateModel(FunctionTemplateModel model, string @namespace, TypeModel typeModel)
        {
            base.PopulateModel(model, @namespace, typeModel);
            model.FunctionName = functionName;

            model.Namespace = @namespace;
            model.Usings.Add("HatTrick.DbEx.Sql.Expression");
            model.ArithmeticOperations = TypeBuilder.CreateBuilder().Add<string>().ToList().Select(@type => new ArithmeticOperationsTemplateModel
            {
                OperationType = @type,
                ReturnType = ArithmeticBuilder.InferReturnTypeByPrecedence(typeModel, @type),
                Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(typeModel, @type).ToList()
            }).ToList();
        }

        public override void Generate(string templatePath, string outputSubdirectory)
            => Generate(templatePath, outputSubdirectory, $"Nullable{TypeBuilder.Get<string>()}{functionName}FunctionExpression.generated.cs", CreateModel("HatTrick.DbEx.MsSql.Expression", TypeBuilder.Get<string>()));
    }
}
