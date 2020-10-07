using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class Int64FieldExpression : 
        FieldExpression<long>,
        IEquatable<Int64FieldExpression>
    {
        #region constructors
        protected Int64FieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(long), entity)
        {

        }

        protected Int64FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(long), entity, alias)
        {

        }
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
