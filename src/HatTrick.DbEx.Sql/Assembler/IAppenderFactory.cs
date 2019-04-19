using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(DbExpressionAssemblerConfiguration config);
    }
}
