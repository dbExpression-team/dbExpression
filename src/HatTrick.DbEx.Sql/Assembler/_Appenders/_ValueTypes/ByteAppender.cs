using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ByteAppender : IAssemblyPartAppender<byte>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart((byte)expression, builder, context);

        public void AppendPart(byte expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (context.CurrentField != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.CurrentField).ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<byte>(expression).ParameterName);
        }
    }
}
