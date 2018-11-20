using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AliasDiscovery
    {
        public IDictionary<EntityExpression, string> Aliases { get; set; } = new Dictionary<EntityExpression, string>();

        public AliasDiscovery(EntityExpression entity, string alias)
        {
            Aliases.Add(entity, alias);
        }

        public AliasDiscovery(IDictionary<EntityExpression, string> aliases)
        {
            Aliases = aliases;
        }
    }
}
