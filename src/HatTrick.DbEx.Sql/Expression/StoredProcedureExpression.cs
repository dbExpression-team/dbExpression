using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class StoredProcedureExpression :
        IEntityExpression,
        AnyEntity,
        ISqlMetadataIdentifierProvider,
        IExpressionProvider<SchemaExpression>,
        IExpressionNameProvider,
        IEquatable<StoredProcedureExpression>
    {
        #region internals
        protected readonly string identifier;
        protected readonly string name;
        protected readonly SchemaExpression schema;
        #endregion

        #region interface
        string ISqlMetadataIdentifierProvider.Identifier => identifier;
        SchemaExpression IExpressionProvider<SchemaExpression>.Expression => schema;
        string IExpressionNameProvider.Name => name;
        #endregion

        #region constructors
        public StoredProcedureExpression(string identifier, string name, SchemaExpression schema)
        {
            this.identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }
        #endregion

        #region to string
        public override string ToString()
            => identifier;
        #endregion

        #region operators
        public static bool operator ==(StoredProcedureExpression obj1, StoredProcedureExpression obj2)
        {
            if (obj1 is null && obj2 is object) return false;
            if (obj1 is object && obj2 is null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(StoredProcedureExpression obj1, StoredProcedureExpression obj2)
            => !(obj1 == obj2);
        #endregion

        #region equals
        public bool Equals(StoredProcedureExpression obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (schema is null && obj.schema is object) return false;
            if (schema is object && obj.schema is null) return false;
            if (!schema.Equals(obj.schema)) return false;

            return identifier.Equals(obj.identifier);
        }

        public override bool Equals(object obj)
            => obj is StoredProcedureExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (identifier is object ? identifier.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
