using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class SingleFieldExpression : 
        FieldExpression<float>,
        IEquatable<SingleFieldExpression>
    {
        #region constructors
        protected SingleFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected SingleFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(SingleFieldExpression obj)
            => obj is SingleFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
