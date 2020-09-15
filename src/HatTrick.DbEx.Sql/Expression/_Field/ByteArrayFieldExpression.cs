using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ByteArrayFieldExpression : 
        FieldExpression<byte[]>,
        IEquatable<ByteArrayFieldExpression>
    {
        #region constructors
        protected ByteArrayFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(byte[]), entity)
        {
        }

        protected ByteArrayFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(byte[]), entity, alias)
        {
        }
        #endregion

        #region equals
        public bool Equals(ByteArrayFieldExpression obj)
            => obj is ByteArrayFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteArrayFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
