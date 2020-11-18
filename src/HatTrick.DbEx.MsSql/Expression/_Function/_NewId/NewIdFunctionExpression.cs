using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class NewIdFunctionExpression : DataTypeFunctionExpression,
        IExpressionElement<Guid>,
        GuidElement,
        IEquatable<NewIdFunctionExpression>
    {
        #region constructors
        public NewIdFunctionExpression() : base(null, typeof(Guid))
        {

        }

        protected NewIdFunctionExpression(string alias) : base(null, typeof(Guid), alias)
        {

        }
        #endregion

        #region methods
        #region as
        public GuidElement As(string alias)
            => new NewIdFunctionExpression(alias);
        #endregion

        #region to string
        public override string ToString() => "NEWID()";
        #endregion

        #region equals
        public bool Equals(NewIdFunctionExpression obj)
            => base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NewIdFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
        #endregion
    }
}
