﻿using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class Int32Appender : IAssemblyPartAppender<int>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart((int)expression, builder, context);
        public void AppendPart(int expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write(builder.Parameters.Add(expression).ParameterName);
        }
    }
}
