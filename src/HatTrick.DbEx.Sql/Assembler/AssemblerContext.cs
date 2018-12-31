using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssemblerContext
    {
        public DbExpressionAssemblerConfiguration Configuration { get; set; } = new DbExpressionAssemblerConfiguration();
        public IDictionary<int, EntityAliasDiscovery> EntityAliases { get; set; } = new Dictionary<int,EntityAliasDiscovery>();
        public int CurrentDepth { get; set; }
        public CurrentFieldContext CurrentField { get; set; }

        public class CurrentFieldContext
        {
            public ISqlFieldMetadata Metadata { get; set; }
            public string NameOverride { get; set; }

            public CurrentFieldContext(ISqlFieldMetadata metadata)
            {
                Metadata = metadata;
            }
        }
    }
}
