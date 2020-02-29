using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class DecimalFieldExpression : 
        FieldExpression<decimal>,
        IEquatable<DecimalFieldExpression>
    {
        #region constructors
        protected DecimalFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected DecimalFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(DecimalFieldExpression obj)
            => obj is DecimalFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
