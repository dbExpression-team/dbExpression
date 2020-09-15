using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableInt32FieldExpression : 
        NullableFieldExpression<int>,
        IEquatable<NullableInt32FieldExpression>
    {
        #region constructors
        protected NullableInt32FieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(int), entity)
        {

        }

        protected NullableInt32FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(int), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableInt32FieldExpression obj)
            => obj is NullableInt32FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
