using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.Sql.Extensions.Assembler
{
    public static class EntityExpressionOverrideExtensions
    {
        public static string ResolveEntityName(this AssemblerContext context, EntityExpression entity)
            => context.ResolveEntityName(entity, context.CurrentDepth);

        public static string ResolveEntityName(this AssemblerContext context, EntityExpression entity, int specifiedLevel)
        {
            if (context.EntityAliases.ContainsKey(specifiedLevel))
            {
                var aliases = context.EntityAliases[specifiedLevel];
                foreach (var alias in aliases.Aliases)
                {
                    if (alias.Entity == entity)
                        return alias.Alias;
                }
            }
            var provider = entity as IExpressionMetadataProvider<EntityExpressionMetadata>;
            return provider.Metadata.IsAliased ? provider.Metadata.AliasName : null;
        }
    }
}
