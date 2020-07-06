using HatTrick.DbEx.CodeTemplating.Builder;
using HatTrick.DbEx.CodeTemplating.Model;
using HatTrick.Text.Templating;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public abstract class CodeGenerator<TModel> : CodeGenerator
        where TModel : TemplateModel, new()
    {
        protected void Generate(string templatePath, string outputSubdirectory, string fileName, TemplateModel data)
        {
            var fileService = new FileService(templatePath, outputSubdirectory);
            string template = fileService.GetTemplate();

            TemplateEngine ngin = new TemplateEngine(template)
            {
                TrimWhitespace = false //global flag for whitespace control...                
            };
            ngin.LambdaRepo.Register("BuildUsings", new Func<IList<string>, string>(usings => usings.Aggregate(string.Empty, (a,b) => $"using {b};{Environment.NewLine}", a => a)));
            //ngin.ProgressListener = (i, s) => Console.WriteLine($"{i}: {s}");
            var output = ngin.Merge(data);
            fileService.WriteFile(fileService.GetOutputPath(fileName), output);
        }

        protected virtual TModel CreateModel(string @namespace, TypeModel @type)
        {
            var context = new TModel();
            PopulateModel(context, @namespace, @type);
            return context;
        }

        protected virtual void PopulateModel(TModel model, string @namespace, TypeModel typeModel)
        {
            model.Namespace = @namespace;
            model.Type = typeModel;
            model.IsOrderBySupported = true;
            model.IsGroupBySupported = true;

            if (typeModel == null || typeModel == TypeBuilder.Get<Guid>() || typeModel == TypeBuilder.Get<bool>()) //Guid and Boolean don't support arithmetic
            {

            }
            else if (typeModel == TypeBuilder.Get<string>()) //String only supports concatenation
            {
                model.ArithmeticOperations = TypeBuilder.CreateBuilder().AddAllTypes().ToList().Select(@type => new ArithmeticOperationsTemplateModel
                {
                    OperationType = @type,
                    ReturnType = TypeBuilder.Get<string>(),
                    Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(typeModel, @type).ToList()
                }).ToList();
            }
            else
            {
                model.ArithmeticOperations = TypeBuilder.CreateBuilder().AddAllTypes().Except(typeof(Guid), typeof(bool)).ToList().Select(@type => new ArithmeticOperationsTemplateModel
                {
                    OperationType = @type,
                    ReturnType = TypeBuilder.InferReturnType(typeModel, @type),
                    Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(typeModel, @type).ToList()
                }).ToList();
            }

            model.FilterOperations = FilterBuilder.CreateBuilder().AddAll().ToList();
        }

        public abstract void Generate(string templatePath, string outputSubdirectory);
    }
}
