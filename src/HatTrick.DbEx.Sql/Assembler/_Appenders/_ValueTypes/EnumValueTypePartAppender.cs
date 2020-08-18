using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EnumValueTypePartAppender : ValueTypePartAppender<Enum>
    {
        public override void AppendPart(Enum value, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field is object)
                builder.Appender.Write(builder.Parameters.Add(value, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add(Convert.ToInt32(value)).ParameterName);
        }
    }
}
