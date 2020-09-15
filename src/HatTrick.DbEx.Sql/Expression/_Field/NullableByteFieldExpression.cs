using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableByteFieldExpression : 
        NullableFieldExpression<byte>,
        IEquatable<NullableByteFieldExpression>
    {
        #region constructors
        protected NullableByteFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(byte), entity)
        {

        }

        protected NullableByteFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(byte), entity, alias)
        {

        }
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
