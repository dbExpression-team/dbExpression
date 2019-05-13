using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class UpdateSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {            
            builder.Appender
                .Indent().Write("UPDATE").LineBreak()
                .Indentation++.Indent();

            context.PushAppendStyle(EntityExpressionAppendStyle.None);
            builder.AppendPart(expression.BaseEntity, context);
            context.PopAppendStyles();

            builder.Appender
                .Indentation--.LineBreak()
                .Indent().Write("SET").LineBreak()
                .Indentation++;

            for (var i = 0; i < expression.Assign.Expressions.Count; i++)
            {
                builder.Appender.Indent();
                builder.AppendPart(expression.Assign.Expressions[i].Expression.LeftPart, context);
                builder.Appender.Write(" = ");
                builder.Appender.Write(
                    builder.Parameters.Add(
                        expression.Assign.Expressions[i].Expression.RightPart.Item2, 
                        expression.Assign.Expressions[i].Expression.LeftPart.Item2 as FieldExpression
                    ).Parameter.ParameterName
                );
                if (i < expression.Assign.Expressions.Count - 1)
                    builder.Appender.Write(",").LineBreak();
            }

            builder.Appender.LineBreak()
                .Indentation--.Indent().Write("FROM").LineBreak()
                .Indentation++.Indent();

            context.PushAppendStyle(EntityExpressionAppendStyle.Declaration);
            builder.AppendPart(expression.BaseEntity, context);
            context.PopAppendStyles();

            builder.Appender.Indentation--;

            if (expression.Joins != null)
            {
                builder.Appender.Indentation++;
                for (var i = 0; i < expression.Joins.Expressions.Count; i++)
                {
                    builder.Appender.Indent();
                    builder.AppendPart(expression.Joins.Expressions[i], context);
                    if (i < expression.Joins.Expressions.Count - 1)
                        builder.Appender.LineBreak();
                }
                builder.Appender.Indentation--;
            }
            builder.Appender.LineBreak();

            if (expression.Where != null)
            {
                 builder.Appender.Indent().Write("WHERE").LineBreak()
                     .Indentation++.Indent();

                 builder.AppendPart(expression.Where, context);

                 builder.Appender.LineBreak()
                     .Indentation--;
             }
        }
        #endregion
    }
}