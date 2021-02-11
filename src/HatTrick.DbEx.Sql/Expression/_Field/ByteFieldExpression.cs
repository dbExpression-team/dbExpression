using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class ByteFieldExpression : 
        FieldExpression<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteFieldExpression>
    {
        #region constructors
        protected ByteFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(string), entity)
        {

        }
        #endregion

        #region as
        public abstract ByteElement As(string alias);
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
