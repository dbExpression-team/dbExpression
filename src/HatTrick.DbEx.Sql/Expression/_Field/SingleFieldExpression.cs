using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class SingleFieldExpression : 
        FieldExpression<float>,
        IEquatable<SingleFieldExpression>
    {
        #region constructors
        protected SingleFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(float), entity)
        {

        }

        protected SingleFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(float), entity, alias)
        {

        }
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
