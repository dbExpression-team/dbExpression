using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EnumAppender : IAssemblyPartAppender<Enum>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart((Enum)expression, builder, context);

        public void AppendPart(Enum expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write(builder.Parameters.Add(Convert.ToInt32(expression)).ParameterName);
        }
    }
}
