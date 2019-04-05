using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DecimalAppender : IAssemblyPartAppender<decimal>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart((decimal)expression, builder, context);

        public void AppendPart(decimal expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (context.CurrentField == null)
                builder.Appender.Write(builder.Parameters.Add<decimal>(expression).ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add(expression, context.CurrentField.Field).Parameter.ParameterName);
        }
    }
}
