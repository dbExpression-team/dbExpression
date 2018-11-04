using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Extensions.Assembler
{
    public static class EntityExpressionOverrideExtensions
    {
        public static bool Contains(this EntityExpressionOverride @override, EntityExpression entity)
        {
            return @override.CurrentScope == OverrideScope.All || @override.Aliases.ContainsKey(entity);
        }

        public static void SetAliasForEntity(this EntityExpressionOverride @override, string alias, EntityExpression entity)
        {
            @override.Aliases[entity] = alias;
        }

        public static void SetAliasesForEntities(this EntityExpressionOverride @override, string alias, SelectExpressionSet selects)
        {
            foreach (var x in selects.Expressions)
            {
                if (x.Expression.Item1.IsAssignableFrom(typeof(FieldExpression)))
                    @override.Aliases[((FieldExpression)x.Expression.Item2).ParentEntity] = alias;
            }
        }

        public static void SetAliasesForAllEntities(this EntityExpressionOverride @override, string alias)
        {
            @override.CurrentScope = OverrideScope.All;
            @override.Alias = alias;
        }

        public static string ResolveEntityName(this EntityExpressionOverride @override, EntityExpression entity)
        {
            if (@override.CurrentScope == OverrideScope.All)
                return @override.Alias;

            if (@override.Aliases.ContainsKey(entity))
                return @override.Aliases[entity];

            return entity.IsAliased ? entity.AliasName : entity.EntityName;
        }
    }
}
