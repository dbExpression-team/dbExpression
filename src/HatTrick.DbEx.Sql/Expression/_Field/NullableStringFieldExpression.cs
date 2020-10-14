using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableStringFieldExpression :
        FieldExpression<string>,
        IEquatable<NullableStringFieldExpression>
    {
        #region constructors
        protected NullableStringFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(float?), entity)
        {

        }

        protected NullableStringFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(float?), entity, alias)
        {

        }
        #endregion

        #region set
        public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new NullableStringExpressionMediator(new LiteralExpression<string>(null)));
        #endregion

        #region equals
        public bool Equals(NullableStringFieldExpression obj)
            => obj is NullableStringFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableStringFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
