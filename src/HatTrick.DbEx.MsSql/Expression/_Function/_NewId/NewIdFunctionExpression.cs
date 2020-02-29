using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class NewIdFunctionExpression : DataTypeFunctionExpression,
        IEquatable<NewIdFunctionExpression>
    {
        #region as
        public new NewIdFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
    }
}
