using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Extensions.Assembler
{
    public static class DictionaryExtensions
    {
        public static void SetAlias(this IDictionary<int, AliasDiscovery> discovery, int level, EntityExpression entity, string alias)
        {
            if (!discovery.ContainsKey(level))
            {
                discovery.Add(level, new AliasDiscovery(entity, alias));
                return;
            }
            discovery[level].Aliases.Add(entity, alias);

        }

        public static void CopyChildrenWithNewAlias(this IDictionary<int, AliasDiscovery> discovery, int level, string alias)
        {
            if (!discovery.ContainsKey(level + 1))
                return;

            foreach (var child in discovery[level + 1].Aliases)
                discovery.SetAlias(level, child.Key, alias);
        }
    }
}
