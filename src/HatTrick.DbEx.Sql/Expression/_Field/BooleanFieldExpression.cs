using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class BooleanFieldExpression : 
        FieldExpression<bool>,
        IEquatable<BooleanFieldExpression>
    {
        #region constructors
        protected BooleanFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected BooleanFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(BooleanFieldExpression obj)
            => obj is BooleanFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is BooleanFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
