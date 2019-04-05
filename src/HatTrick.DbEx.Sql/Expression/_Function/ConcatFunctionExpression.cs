using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ConcatFunctionExpression :
        IDbFunctionExpression,
        IAssemblyPart,
        IDbExpressionAliasProvider,
        IEquatable<ConcatFunctionExpression>,
        ISupportedForSelectExpression
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public IList<(Type, object)> Expressions { get; protected set; } = new List<(Type, object)>();

        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        internal ConcatFunctionExpression()
        {
        }

        public ConcatFunctionExpression(IList<ISupportedForFunctionExpression<ConcatFunctionExpression, string>> expressions, string value)
        {
        }

        public ConcatFunctionExpression(IList<ISupportedForFunctionExpression<ConcatFunctionExpression, string>> expressions)
        {
            Expressions = expressions.Select(e => (e.GetType(), (object)e)).ToList();
        }
        #endregion

        #region as
        public ConcatFunctionExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ConcatFunctionExpression obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (this.Expressions == default && obj.Expressions != default) return false;
            if (obj.Expressions == default && this.Expressions != default) return false;
            if (obj.Expressions.Count != this.Expressions.Count) return false;

            foreach (var exp in Expressions)
                if (!obj.Expressions.Any(e => e.Equals(exp))) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is ConcatFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(ConcatFunctionExpression a) => new SelectExpression(a);
        #endregion
    }
}
