using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class NullableGuidAppender : IAssemblyPartAppender<Guid?>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart((Guid?)expression, builder, context);

        public void AppendPart(Guid? expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<Guid?>(expression).ParameterName);
        }
    }
}
