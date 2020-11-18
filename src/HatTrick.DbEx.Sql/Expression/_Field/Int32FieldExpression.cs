using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class Int32FieldExpression : 
        FieldExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32FieldExpression>
    {
        #region constructors
        protected Int32FieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(int), entity)
        {

        }

        protected Int32FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(int), entity, alias)
        {

        }
        #endregion

        #region as
        public abstract Int32Element As(string alias);
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
