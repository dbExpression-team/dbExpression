using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class StringFieldExpression : 
        FieldExpression<string>,
        IEquatable<StringFieldExpression>
    {
        #region constructors
        protected StringFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected StringFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
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
