using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class StringFieldExpression : 
        FieldExpression<string>,
        IEquatable<StringFieldExpression>
    {
        #region constructors
        protected StringFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected StringFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(StringFieldExpression obj)
            => obj is StringFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
