using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class ByteFieldExpression : 
        FieldExpression<byte>,
        IEquatable<ByteFieldExpression>
    {
        #region constructors
        protected ByteFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(string), entity)
        {

        }

        protected ByteFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(string), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(ByteFieldExpression obj)
            => obj is ByteFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
