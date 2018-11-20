using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class Int64Appender : IAssemblyPartAppender<long>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart((long)expression, builder, context);

        public void AppendPart(long expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write(builder.Parameters.Add(expression).ParameterName);
        }
    }
}
