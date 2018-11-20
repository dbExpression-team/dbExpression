using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssemblerContext
    {
        public DbExpressionAssemblerConfiguration Configuration { get; set; } = new DbExpressionAssemblerConfiguration();
        public IDictionary<int, AliasDiscovery> EntityAliases { get; set; } = new Dictionary<int,AliasDiscovery>();
        public int CurrentDepth { get; set; }
    }
}
