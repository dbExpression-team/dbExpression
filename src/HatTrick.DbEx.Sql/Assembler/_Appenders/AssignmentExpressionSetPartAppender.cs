using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssignmentExpressionSetPartAppender : PartAppender<AssignmentExpressionSet>
    {
        public override void AppendPart(AssignmentExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            throw new NotImplementedException("Should be handled by outer builder.");
        }
    }
}
