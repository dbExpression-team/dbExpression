using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class Int16Appender : IAssemblyPartAppender<short>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart((short)expression, builder, context);

        public void AppendPart(short expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write(builder.Parameters.Add(expression).ParameterName);
        }
    }
}
