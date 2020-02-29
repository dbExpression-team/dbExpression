using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DBNullValueTypePartAppender : IAssemblyPartAppender<DBNull>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
           => AppendPart((DBNull)expression, builder, context);

        public void AppendPart(DBNull expression, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.Appender.Write("NULL");
    }
}
