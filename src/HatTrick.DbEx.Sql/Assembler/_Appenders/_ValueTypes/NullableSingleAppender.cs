using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class NullableSingleAppender : IAssemblyPartAppender<float?>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart((float?)expression, builder, context);

        public void AppendPart(float? expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<decimal?>(expression).ParameterName);
        }
    }
}
