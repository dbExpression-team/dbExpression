﻿using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class LiteralAppender :
        IAssemblyPartAppender<LiteralExpression>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as LiteralExpression, builder, context);

        public void AppendPart(LiteralExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write(builder.Parameters.Add(expression.Expression.Item2, expression.Expression.Item1).ParameterName);
        }
    }
}
