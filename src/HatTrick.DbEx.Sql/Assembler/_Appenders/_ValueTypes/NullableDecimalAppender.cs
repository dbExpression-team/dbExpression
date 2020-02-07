using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class NullableDecimalAppender : IAssemblyPartAppender<decimal?>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart((decimal?)expression, builder, context);

        public void AppendPart(decimal? expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<decimal?>(expression).ParameterName);
        }
    }
}
