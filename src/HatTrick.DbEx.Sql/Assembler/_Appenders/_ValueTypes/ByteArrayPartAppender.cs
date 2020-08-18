namespace HatTrick.DbEx.Sql.Assembler
{
    public class ByteArrayPartAppender : IAssemblyPartAppender<byte[]>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
           => AppendPart((byte[])expression, builder, context);

        public void AppendPart(byte[] expression, ISqlStatementBuilder builder, AssemblyContext context)
            =>  builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);

    }
}
