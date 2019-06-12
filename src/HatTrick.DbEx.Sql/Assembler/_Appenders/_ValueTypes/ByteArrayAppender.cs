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
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
           => AppendPart((byte[])expression, builder, context);

        public void AppendPart(byte[] expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<byte[]>(expression).ParameterName);
        }
    }
}
