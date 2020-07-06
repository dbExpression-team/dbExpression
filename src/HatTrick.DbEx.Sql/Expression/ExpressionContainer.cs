using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ExpressionContainer :
        IEquatable<ExpressionContainer>
    {
        #region interface
        public Type Type { get; set; }
        public object Object { get; set; }
        #endregion

        #region constructors
        public ExpressionContainer(object @object, Type @type)
        {
            Object = @object ?? throw new ArgumentNullException($"{nameof(@object)} is required.");
            Type = @type ?? throw new ArgumentNullException($"{nameof(@type)} is required.");
        }

        public ExpressionContainer(object @object)
        {
            Object = @object ?? throw new ArgumentNullException($"{nameof(@object)} is required.");
            Type = @object.GetType();
        }
        #endregion

        #region methods
        public override string ToString()
            => $"({Type}, {Object})";
        #endregion

        #region equals
        public bool Equals(ExpressionContainer obj)
        {
            if (Type is null && obj.Type is object) return false;
            if (Type is object && obj.Type is null) return false;
            if (!Type.Equals(obj.Type)) return false;

            if (Object is null && obj.Object is object) return false;
            if (Object is object && obj.Object is null) return false;
            if (!Object.Equals(obj.Object)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is ExpressionContainer exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Type is object ? Type.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Object is object ? Object.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
