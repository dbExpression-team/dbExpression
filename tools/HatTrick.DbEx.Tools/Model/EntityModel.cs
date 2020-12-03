using HatTrick.DbEx.Tools.Service;
using HatTrick.Model.MsSql;
using System;

namespace HatTrick.DbEx.Tools.Model
{
    public class EntityModel
    {
        private INamedMeta _entity;
        private string _namespace;
        private CodeGenerationHelpers _helpers;

        public string Namespace => $"{_helpers.ResolveRootNamespace()}{_namespace}DataService";
        public string Name => _helpers.ResolveName(_entity);

        public EntityModel(INamedMeta entity, CodeGenerationHelpers helpers)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            _helpers = helpers ?? throw new ArgumentNullException(nameof(helpers));
            _namespace = entity is MsSqlTable table ? helpers.ResolveName(table.GetParent()) : helpers.ResolveName((entity as MsSqlView).GetParent());
        }
    }
}
