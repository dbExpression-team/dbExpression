using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class Int16FieldExpression : 
        FieldExpression<short>,
        IEquatable<Int16FieldExpression>
    {
        #region constructors
        protected Int16FieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected Int16FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(Int16FieldExpression obj)
            => obj is Int16FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
