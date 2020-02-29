using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class SingleFieldExpression : 
        FieldExpression<float>,
        IEquatable<SingleFieldExpression>
    {
        #region constructors
        protected SingleFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected SingleFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
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
