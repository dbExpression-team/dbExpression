namespace HatTrick.DbEx.Sql.Assembler
{
    public class ByteArrayPartAppender : IAssemblyPartAppender<byte[]>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
           => AppendPart((byte[])expression, builder, context);

        public void AppendPart(byte[] expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field is object)
                builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<byte[]>(expression).ParameterName);
        }
    }
}
