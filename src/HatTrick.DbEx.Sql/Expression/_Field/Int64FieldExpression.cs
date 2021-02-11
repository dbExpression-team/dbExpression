using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class Int64FieldExpression : 
        FieldExpression<long>,
        Int64Element,
        AnyInt64Element,
        IEquatable<Int64FieldExpression>
    {
        #region constructors
        protected Int64FieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(long), entity)
        {

        }
        #endregion

        #region as
        public abstract Int64Element As(string alias);
        #endregion

        #region equals
        public bool Equals(Int64FieldExpression obj)
            => obj is Int64FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
