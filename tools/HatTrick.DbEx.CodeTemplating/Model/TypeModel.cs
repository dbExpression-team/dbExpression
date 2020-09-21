using System;

namespace HatTrick.DbEx.CodeTemplating.Model
{
    public class TypeModel : IEquatable<TypeModel>
    {
        public Type Type { get; }
        public string Name { get; private set; }
        public string Alias { get; private set; }
        public bool IsNullable { get => Type != typeof(string); }

        public TypeModel(Type type, string alias)
        {
            Type = type;
            Name = type.Name;
            Alias = alias;
        }

        public TypeModel(Type type, string name, string alias)
        {
            Type = type;
            Name = name;
            Alias = alias;
        }

        public override string ToString()
        {
            return Type.Name;
        }

        #region equals
        public static bool operator ==(TypeModel obj1, TypeModel obj2)
        {
            if (ReferenceEquals(obj1, obj2)) return true;
            if (ReferenceEquals(obj1, null)) return false;
            if (ReferenceEquals(obj2, null)) return false;
            return obj1.Type == obj2.Type;
        }

        public static bool operator !=(TypeModel obj1, TypeModel obj2)
            => !(obj1 == obj2);

        public bool Equals(TypeModel obj)
            => obj is TypeModel t && Type == t.Type;

        public override bool Equals(object obj)
            => obj is TypeModel t && Type == t.Type;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
