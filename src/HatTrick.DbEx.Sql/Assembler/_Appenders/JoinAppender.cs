using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinAppender : 
        IAssemblyPartAppender<JoinExpressionSet>,
        IAssemblyPartAppender<JoinExpression>,
        IAssemblyPartAliasProvider<JoinExpression>
    {        
        public void AppendPart(JoinExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            throw new NotImplementedException("Should be handled by outer builder");
        }

        public void DiscoverAliases(object expression, ISqlStatementBuilder builder, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, AliasDiscovery> discoveredAliases)
            => DiscoverAliases(expression as JoinExpression, builder, currentLevel, config, discoveredAliases);

        public void DiscoverAliases(JoinExpression expression, ISqlStatementBuilder builder, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, AliasDiscovery> discoveredAliases)
        {
            if (!(expression.JoinToo.Item2 is ExpressionSet joinExpression))
                return;

            var provider = joinExpression.BaseEntity as IExpressionMetadataProvider<EntityExpressionMetadata>;
            string subselectBaseAlias = provider.Metadata.IsAliased ? provider.Metadata.AliasName : builder.GenerateAlias();
            discoveredAliases.SetAlias(currentLevel, joinExpression.BaseEntity, subselectBaseAlias);

            if (joinExpression.Joins == null)
                return;

            foreach (var join in joinExpression.Joins.Expressions)
            {
                if (!(join.JoinToo.Item2 is ExpressionSet child))
                    continue;

                builder.DiscoverAliases(child, currentLevel + 1, config, discoveredAliases);

                var childProvider = child.BaseEntity as IExpressionMetadataProvider<EntityExpressionMetadata>;
                string childAlias = childProvider.Metadata.IsAliased ? childProvider.Metadata.AliasName : builder.GenerateAlias();
                discoveredAliases.SetAlias(currentLevel + 1, child.BaseEntity, childAlias);
            }

            discoveredAliases.CopyChildrenWithNewAlias(currentLevel, subselectBaseAlias);

            return;
        }

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as JoinExpression, builder, context);

        public void AppendPart(JoinExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (expression.JoinToo.Item1 == typeof(ExpressionSet))
            {
                var joinExpression = expression.JoinToo.Item2 as ExpressionSet;

                builder.Appender.Indent().Write(expression.JoinType.ToString())
                    .Write(" JOIN (").LineBreak()
                    .Indentation++;

                context.CurrentDepth++;
                builder.AppendPart<ExpressionSet>(joinExpression, context);
                context.CurrentDepth--;

                builder.Appender.Indentation--.Indent().Write(") AS ")
                    .Write(context.ResolveEntityName(joinExpression.BaseEntity))
                    .Write(" ON ");

                builder.AppendPart<JoinOnExpression>(expression.JoinOnExpression, context);

                return;
            }
            builder.Appender.Indent().Write(expression.JoinType.ToString());
            builder.Appender.Write(" JOIN ");
            builder.AppendPart(expression.JoinToo, context);
            if (expression.JoinType == JoinOperationExpressionOperator.CROSS)
                return;
            builder.Appender.Write(" ON ");
            builder.AppendPart<JoinOnExpression>(expression.JoinOnExpression, context);
        }
    }
}
