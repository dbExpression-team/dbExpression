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
        public static void SetAlias(this IDictionary<int, EntityAliasDiscovery> discovery, int level, EntityAlias alias)
        {
            if (!discovery.ContainsKey(level))
            {
                discovery.Add(level, new EntityAliasDiscovery(alias));
                return;
            }
            discovery[level].Aliases.Add(alias);
        }

        public static void RemoveAlias(this IDictionary<int, EntityAliasDiscovery> discovery, int level, EntityAlias alias)
        {
            if (!discovery.ContainsKey(level))
                return;

            var x = discovery[level].Aliases.SingleOrDefault(e => e.Entity == alias.Entity);
            if (x == null)
                return;

            if (x.Alias != alias.Alias)
                return;

            discovery[level].Aliases.Remove(x);
        }

        public static void SetAliasesOnChildren(this IDictionary<int, EntityAliasDiscovery> discovery, int level, string alias)
        {
            if (!discovery.ContainsKey(level + 1))
                return;

            foreach (var child in discovery[level + 1].Aliases)
                discovery.SetAlias(level, new EntityAlias(child.Entity, alias));
        }
    }
}
