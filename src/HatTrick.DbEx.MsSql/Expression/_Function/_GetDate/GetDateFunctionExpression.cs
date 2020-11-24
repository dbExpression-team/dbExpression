using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class GetDateFunctionExpression : DataTypeFunctionExpression,
        IExpressionElement<DateTime>,
        DateTimeElement,
        IExpressionAliasProvider,
        IEquatable<GetDateFunctionExpression>
    {
        #region constructors
        public GetDateFunctionExpression() : base(null, typeof(DateTime))
        { 
        
        }
        #endregion

        #region methods
        #region as
        public DateTimeElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => "GETDATE()";
        #endregion

        #region equals
        public bool Equals(GetDateFunctionExpression obj)
            => base.Equals(obj); 

        public override bool Equals(object obj)
            => obj is GetDateFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
        #endregion
    }
}
