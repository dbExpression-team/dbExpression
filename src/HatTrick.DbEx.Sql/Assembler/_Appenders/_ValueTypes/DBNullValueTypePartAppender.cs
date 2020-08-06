using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DBNullValueTypePartAppender : IAssemblyPartAppender<DBNull>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
           => AppendPart((DBNull)expression, builder, context);

        public void AppendPart(DBNull expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field is object)
                builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write("NULL");
        }
    }
}
