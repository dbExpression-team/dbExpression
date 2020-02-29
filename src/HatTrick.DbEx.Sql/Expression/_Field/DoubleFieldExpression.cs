using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class DoubleFieldExpression : 
        FieldExpression<double>,
        IEquatable<DoubleFieldExpression>
    {
        #region constructors
        protected DoubleFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected DoubleFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(DoubleFieldExpression obj)
            => obj is DoubleFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
