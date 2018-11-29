using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class EntityExpressionMetadata : IExpressionMetadata
    {
        #region interface
        public SchemaExpression Schema { get; set; }
        public string EntityName { get; set; }
        public string AliasName { get; set; }
        public bool IsAliased => !string.IsNullOrWhiteSpace(AliasName);
        #endregion

        #region constructors
        public EntityExpressionMetadata(SchemaExpression schema, string entityName)
        {
            Schema = schema;
            EntityName = entityName;
        }

        public EntityExpressionMetadata(SchemaExpression schema, string entityName, string aliasName)
        {
            Schema = schema;
            EntityName = entityName;
            AliasName = aliasName;
        }
        #endregion
    }
}
