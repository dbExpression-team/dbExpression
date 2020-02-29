using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class DateTimeFieldExpression : 
        FieldExpression<DateTime>,
        IEquatable<DateTimeFieldExpression>
    {
        #region constructors
        protected DateTimeFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected DateTimeFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(DateTimeFieldExpression obj)
            => obj is DateTimeFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
