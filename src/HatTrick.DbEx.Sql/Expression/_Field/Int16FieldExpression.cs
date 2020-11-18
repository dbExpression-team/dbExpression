using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class Int16FieldExpression : 
        FieldExpression<short>,
        Int16Element,
        AnyInt16Element,
        IEquatable<Int16FieldExpression>
    {
        #region constructors
        protected Int16FieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(short), entity)
        {

        }

        protected Int16FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(short), entity, alias)
        {

        }
        #endregion

        #region as
        public abstract Int16Element As(string alias);
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
