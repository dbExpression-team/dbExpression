using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(DbExpressionAssemblerConfiguration config) => new Appender(config);
    }
}
