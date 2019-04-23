using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Assembler
{
    //NOTE: JRod, not really a value type, but handled exactly the same...
    public class ByteArrayAppender : IAssemblyPartAppender<byte[]>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
           => AppendPart((byte[])expression, builder, context);

        public void AppendPart(byte[] expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (context.CurrentField != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.CurrentField.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<byte[]>(expression).ParameterName);
        }
    }
}
