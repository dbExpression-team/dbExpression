using HatTrick.DbEx.Tools.Service;
using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Tools.Model
{
    public class ViewTemplateModel : ISqlEntityModel
    {
        private readonly MsSqlView _view;
        private readonly CodeGenerationHelpers _helpers;

        public string SchemaName => _view.GetParent().Name;
        public string Name => _helpers.ResolveName(_view);
        public string TypeName => "view";
            public EntityModel Entity { get; }
            public DocumentationPropertiesModel Documentation { get; }

        public ViewTemplateModel(MsSqlView view, CodeGenerationHelpers helpers)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _helpers = helpers ?? throw new ArgumentNullException(nameof(helpers));
            Entity = new EntityModel(view, helpers);
            Documentation = new DocumentationPropertiesModel(new Dictionary<string,string> { { "name", view.Name } });
        }
    }
}
