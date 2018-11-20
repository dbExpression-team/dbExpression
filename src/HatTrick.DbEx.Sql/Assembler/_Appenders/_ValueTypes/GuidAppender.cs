using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GuidAppender : IAssemblyPartAppender<Guid>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart((Guid)expression, builder, context);

        public void AppendPart(Guid expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write(builder.Parameters.Add(expression).ParameterName);
        }
    }
}
