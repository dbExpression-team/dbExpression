using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class SingleFieldExpression : 
        FieldExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleFieldExpression>
    {
        #region constructors
        protected SingleFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(float), entity)
        {

        }
        #endregion

        #region as
        public abstract SingleElement As(string alias);
        #endregion

        #region equals
        public bool Equals(SingleFieldExpression obj)
            => obj is SingleFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
