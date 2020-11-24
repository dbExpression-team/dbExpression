using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableByteFieldExpression : 
        NullableFieldExpression<byte,byte?>,
        NullableByteElement,
        AnyByteElement,
        IEquatable<NullableByteFieldExpression>
    {
        #region constructors
        protected NullableByteFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected NullableByteFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public abstract NullableByteElement As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableByteFieldExpression obj)
            => obj is NullableByteFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
