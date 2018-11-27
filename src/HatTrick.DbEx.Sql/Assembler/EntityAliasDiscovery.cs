using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EntityAliasDiscovery
    {
        public IList<EntityAlias> Aliases { get; set; } = new List<EntityAlias>();

        public EntityAliasDiscovery(EntityAlias alias)
        {
            Aliases.Add(alias);
        }

        public EntityAliasDiscovery(IList<EntityAlias> aliases)
        {
            Aliases = aliases;
        }
    }
}
