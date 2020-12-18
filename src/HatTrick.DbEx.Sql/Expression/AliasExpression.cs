using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class AliasExpression :
        ObjectElement,
        IExpressionElement<object>,
        IExpressionTypeProvider,
        IEquatable<AliasExpression>
    {
        #region interface
        public string TableAlias { get; private set; }
        public string FieldAlias { get; private set; }
        Type IExpressionTypeProvider.DeclaredType => typeof(object);

        #endregion

        #region constructors
        public AliasExpression(string tableAlias, string fieldAlias)
        {
            if (string.IsNullOrWhiteSpace(tableAlias))
                throw new ArgumentException($"{nameof(tableAlias)} is required.");
            if (string.IsNullOrWhiteSpace(fieldAlias))
                throw new ArgumentException($"{nameof(tableAlias)} is required.");

            TableAlias = tableAlias;
            FieldAlias = fieldAlias;
        }
        #endregion

        #region as
        public ObjectElement As(string alias)
            => new ObjectSelectExpression(this).As(alias);
        #endregion

        #region to string
        public override string ToString()
            => $"{TableAlias}.{FieldAlias}";
        #endregion

        #region equals
        public bool Equals(AliasExpression obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!StringComparer.Ordinal.Equals(TableAlias, obj.TableAlias)) return false;
            if (!StringComparer.Ordinal.Equals(FieldAlias, obj.FieldAlias)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is AliasExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (TableAlias is object ? TableAlias.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (FieldAlias is object ? FieldAlias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
