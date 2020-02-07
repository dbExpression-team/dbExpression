using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class NullableInt16Appender : IAssemblyPartAppender<short?>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart((short?)expression, builder, context);

        public void AppendPart(short? expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<short?>(expression).ParameterName);
        }
    }
}
