using HatTrick.DbEx.Sql.Assembler;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql
{
    public class SqlStatement
    {
        public IAppender CommandTextWriter { get; set; }
        public DbCommandType CommandType { get; set; } = DbCommandType.SqlText;
        public IList<ParameterizedFieldExpression> Parameters { get; set; } = new List<ParameterizedFieldExpression>();

        public SqlStatement()
        { }

        public SqlStatement(IAppender commandTextWriter, IList<ParameterizedFieldExpression> parameters, DbCommandType commandType)
        {
            CommandTextWriter = commandTextWriter;
            Parameters = parameters;
            CommandType = commandType;
        }
    }
}
