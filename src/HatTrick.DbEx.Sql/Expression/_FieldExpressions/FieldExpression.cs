using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FieldExpression : 
        IDbExpression,
        IAssemblyPart,
        IDbExpressionMetadataProvider<ISqlFieldMetadata>,
        IDbExpressionProvider<EntityExpression>,
        ISupportedForExpression<OrderByExpression>,
        IDbExpressionAliasProvider
    {
        #region internals
        protected EntityExpression Entity { get; }
        protected ISqlFieldMetadata Metadata { get; }
        protected string Alias { get; }
        #endregion

        #region interface
        EntityExpression IDbExpressionProvider<EntityExpression>.Expression => Entity;
        ISqlFieldMetadata IDbExpressionMetadataProvider<ISqlFieldMetadata>.Metadata => Metadata;
        string IDbExpressionAliasProvider.Alias => Alias;
        public OrderByExpression Asc => new OrderByExpression((GetType(), this), OrderExpressionDirection.ASC);
        public OrderByExpression Desc => new OrderByExpression((GetType(), this), OrderExpressionDirection.DESC);
        #endregion

        #region constructors
        protected FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata) : this(entity, metadata, null)
        {
        }

        protected FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, string alias)
        {
            Entity = entity;
            Metadata = metadata;
            Alias = alias;
        }
        #endregion

        #region map
        public abstract void Map(object instance, object value);
        #endregion

        #region to string
        public override string ToString() => this.ToString("[s].[e].[f]");

        public string ToString(string format, bool ignoreAlias = false)
        {
            string val = null;
            switch (format)
            {
                case "f":
                    val = this.Metadata.Name;
                    break;
                case "[f]":
                    val = $"[{this.Metadata.Name}]";
                    break;
                case "e.f":
                    val = $"{this.Metadata.Entity.Name}.{this.Metadata.Name}";
                    break;
                case "s.e.f":
                    val = $"{this.Metadata.Entity.Schema.Name}.{this.Metadata.Entity.Name}.{this.Metadata.Name}";
                    break;
                case "[s].[e].[f]":
                    val = $"[{this.Metadata.Entity.Schema.Name}].[{this.Metadata.Entity.Name}].[{this.Metadata.Name}]";
                    break;
                case "[s.e.f]":
                    val = $"[{this.Metadata.Entity.Schema.Name}.{this.Metadata.Entity.Name}.{this.Metadata.Name}]";
                    break;
                default:
                    throw new ArgumentException($"encountered unknown format string: {format} valid formats are 'e','f','[e]','[f]','e.f','[e].[f]', s.e.f, [s].[e].[f], [s.e.f]", "format");
            }

            if (!ignoreAlias && !string.IsNullOrWhiteSpace(Alias))
            {
                val += $" AS {Alias}";
            }

            return val;
        }
        #endregion

        #region set field
        public AssignmentExpression Set(IDbExpression expression) => new AssignmentExpression(this, expression);
        #endregion

        #region implicit operators
        public static implicit operator OrderByExpression(FieldExpression field) => new OrderByExpression((field.GetType(), field), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(FieldExpression field) => new GroupByExpression((field.GetType(), field));
        #endregion

        #region equals
        public bool Equals(FieldExpression obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.Alias != this.Alias) return false;
            if (obj.Metadata != this.Metadata) return false;

            return true;
        }

        public override bool Equals(object obj)
            => Equals(obj as FieldExpression);

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(FieldExpression obj1, FieldExpression obj2)
        {
            if (ReferenceEquals(obj1, obj2)) return true;
            if (ReferenceEquals(obj1, null)) return false;
            if (ReferenceEquals(obj2, null)) return false;
            return obj1.Equals(obj2);
        }

        public static bool operator !=(FieldExpression obj1, FieldExpression obj2)
            => !(obj1 == obj2);
        #endregion
    }

}
