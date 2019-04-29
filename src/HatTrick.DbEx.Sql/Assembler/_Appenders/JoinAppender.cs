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

        public void DiscoverAliases(object expression, ISqlStatementBuilder builder, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, EntityAliasDiscovery> discoveredAliases)
            => DiscoverAliases(expression as JoinExpression, builder, currentLevel, config, discoveredAliases);

        public void DiscoverAliases(JoinExpression expression, ISqlStatementBuilder builder, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, EntityAliasDiscovery> discoveredAliases)
        {
            //if the join condition joins to a table with the same name but in different schemas, generate alias
            var leftEntity = (expression.JoinOnExpression.LeftPart.Item2 as IDbExpressionMetadataProvider<ISqlFieldMetadata>)?.Metadata?.Entity;
            var joinTooEntity = expression.JoinToo.Item2 as EntityExpression;
            if (joinTooEntity != null && leftEntity != null)
            {
                var joinTooEntityMetadata = joinTooEntity as IDbExpressionMetadataProvider<ISqlEntityMetadata>;
                if (string.Compare(leftEntity.Name, joinTooEntityMetadata.Metadata.Name, true) == 0)
                {
                    if (string.Compare(leftEntity.Name, joinTooEntityMetadata.Metadata.Schema.Name, true) != 0)
                    {
                        discoveredAliases.SetAlias(currentLevel, new EntityAlias(joinTooEntity, (joinTooEntity as IDbExpressionAliasProvider).Alias ?? builder.GenerateAlias()));
                    }
                }
            }

            if (!(expression.JoinToo.Item2 is ExpressionSet joinExpression))
                return;

            var provider = joinExpression.BaseEntity as IDbExpressionAliasProvider;
            string subselectBaseAlias = string.IsNullOrWhiteSpace(provider.Alias) ? builder.GenerateAlias() : provider.Alias;
            discoveredAliases.SetAlias(currentLevel, new EntityAlias(joinExpression.BaseEntity, subselectBaseAlias));

            if (joinExpression.Joins == null)
                return;

            foreach (var join in joinExpression.Joins.Expressions)
            {
                if (!(join.JoinToo.Item2 is ExpressionSet child))
                    continue;

                builder.DiscoverAliases(child, currentLevel + 1, config, discoveredAliases);

                var childProvider = child.BaseEntity as IDbExpressionAliasProvider;
                string childAlias = string.IsNullOrWhiteSpace(childProvider.Alias) ? builder.GenerateAlias() : childProvider.Alias;
                discoveredAliases.SetAlias(currentLevel + 1, new EntityAlias(child.BaseEntity, childAlias));
            }

            discoveredAliases.SetAliasesOnChildren(currentLevel, subselectBaseAlias);

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
                    .Write(context.Configuration.IdentifierDelimiter.Begin)
                    .Write(context.ResolveEntityAlias(joinExpression.BaseEntity))
                    .Write(context.Configuration.IdentifierDelimiter.End)
                    .Write(" ON ");

                builder.AppendPart<JoinOnExpression>(expression.JoinOnExpression, context);

                return;
            }
            builder.Appender.Indent().Write(expression.JoinType.ToString());
            builder.Appender.Write(" JOIN ");
            builder.AppendPart(expression.JoinToo, context);
            var alias = expression.JoinToo.Item2 is EntityExpression entity ? context.ResolveEntityAlias(entity) : null;
            if (!string.IsNullOrWhiteSpace(alias))
            {
                builder.Appender.Write(" AS ");
                builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
                builder.Appender.Write(alias);
                builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);
            }
            if (expression.JoinType == JoinOperationExpressionOperator.CROSS)
                return;
            builder.Appender.Write(" ON ");
            builder.AppendPart<JoinOnExpression>(expression.JoinOnExpression, context);
        }
    }
}
