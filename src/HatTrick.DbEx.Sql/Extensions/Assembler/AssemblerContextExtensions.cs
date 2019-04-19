using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.Sql.Extensions.Assembler
{
    public static class AssemblerContextExtensions
    {
        public static string ResolveEntityAlias(this AssemblerContext context, EntityExpression entity)
            => context.ResolveEntityAlias(entity, context.CurrentDepth);

        public static string ResolveEntityAlias(this AssemblerContext context, EntityExpression entity, int specifiedLevel)
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
            return null;
        }
    }
}
