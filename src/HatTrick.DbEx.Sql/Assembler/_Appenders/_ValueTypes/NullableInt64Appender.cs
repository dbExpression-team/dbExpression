using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class NullableInt64Appender : IAssemblyPartAppender<long?>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart((long?)expression, builder, context);

        public void AppendPart(long? expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<long?>(expression).ParameterName);
        }
    }
}
