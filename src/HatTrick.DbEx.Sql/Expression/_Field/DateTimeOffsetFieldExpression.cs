using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class DateTimeOffsetFieldExpression : 
        FieldExpression<DateTimeOffset>,
        IEquatable<DateTimeOffsetFieldExpression>
    {
        #region constructors
        protected DateTimeOffsetFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected DateTimeOffsetFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetFieldExpression obj)
            => obj is DateTimeOffsetFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
