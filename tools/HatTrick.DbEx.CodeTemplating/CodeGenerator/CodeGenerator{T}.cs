using HatTrick.DbEx.CodeTemplating.Builder;
using HatTrick.DbEx.CodeTemplating.Model;
using HatTrick.Text.Templating;
using System;
using System.Collections.Generic;
using System.IO;
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

            TemplateEngine ngin = new(template)
            {
                TrimWhitespace = false //global flag for whitespace control...                
            };
            ngin.LambdaRepo.Register("GetArithmeticOperationsForType", (Func<IList<ArithmeticOperationsTemplateModel>, Type, IList<ArithmeticOperationTemplateModel>>)((operations, type) => operations.SingleOrDefault(x => x.OperationType?.Type == type)?.Operations ?? new List<ArithmeticOperationTemplateModel>()));
            ngin.LambdaRepo.Register("IsTypeOfObject", (Func<Type, bool>)((type) => type == typeof(object)));
            ngin.LambdaRepo.Register("IsNotTypeOfObject", (Func<Type, bool>)((type) => type != typeof(object)));
            ngin.LambdaRepo.Register("IsSameType", (Func<TypeModel, TypeModel, bool>)((t1, t2) => t1.Type == t2.Type));
            ngin.LambdaRepo.Register("IsNotSameType", (Func<TypeModel, TypeModel, bool>)((t1, t2) => t1.Type != t2.Type));
            //ngin.ProgressListener = (i, s) => Console.WriteLine($"{i}: {s}");
            var output = ngin.Merge(data);
            FileService.WriteFile(fileService.GetOutputPath(fileName), output);
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

            if (model.Type is null || model.Type == TypeBuilder.Get<Guid>() || model.Type == TypeBuilder.Get<bool>() || model.Type == TypeBuilder.Get<object>()) //Guid, Boolean, and Object don't support arithmetic
            {

            }
            else if (model.Type == TypeBuilder.Get<string>()) //String only supports concatenation
            {
                model.ArithmeticOperations = TypeBuilder.CreateBuilder().AddAllTypes().Except<object>().ToList().Select(@type => new ArithmeticOperationsTemplateModel
                {
                    OperationType = @type,
                    ReturnType = TypeBuilder.Get<string>(),
                    Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(model.Type, @type).ToList()
                }).ToList();
            }
            else
            {
                model.ArithmeticOperations = TypeBuilder.CreateBuilder().AddAllTypes().Except(typeof(Guid), typeof(bool), typeof(object)).ToList().Select(@type => new ArithmeticOperationsTemplateModel
                {
                    OperationType = @type,
                    ReturnType = TypeBuilder.InferReturnType(model.Type, @type),
                    Operations = ArithmeticBuilder.CreateBuilder().InferArithmeticOperations(model.Type, @type).ToList()
                }).ToList();
            }

            model.Filters = TypeBuilder.CreateBuilder().Add(model.Type!).ToList().Select(@type => new FilterOperationsTemplateModel
            {
                Type = type,
                Operations = FilterBuilder.CreateBuilder().InferFilterOperations(model.Type!, @type).ToList()
            }).ToList();
        }

        public abstract void Generate(string templatePath, string outputSubdirectory);
    }
}
