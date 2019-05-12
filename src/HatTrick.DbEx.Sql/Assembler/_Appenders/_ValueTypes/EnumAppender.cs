using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EnumAppender : IAssemblyPartAppender<Enum>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart((Enum)expression, builder, context);

        public void AppendPart(Enum expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(Convert.ToInt32(expression), context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<int>(Convert.ToInt32(expression)).ParameterName);
        }
    }
}
