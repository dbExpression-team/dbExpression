using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class Int32FieldExpression : 
        FieldExpression<int>,
        IEquatable<Int32FieldExpression>
    {
        #region constructors
        protected Int32FieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected Int32FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(Int32FieldExpression obj)
            => obj is Int32FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
