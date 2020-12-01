using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectCastFunctionExpression :
        CastFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectCastFunctionExpression>
    {
        #region constructors
        public ObjectCastFunctionExpression(AnyObjectElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public ObjectElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ObjectCastFunctionExpression obj)
            => obj is ObjectCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
