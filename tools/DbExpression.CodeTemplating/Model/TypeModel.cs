using System;

namespace DbExpression.CodeTemplating.Model
{
    public class TypeModel : IEquatable<TypeModel>
    {
        public Type Type { get; }
        public string Name { get; private set; }
        public string Alias { get; private set; }
        public string NullableAlias => IsNullable ? $"{Alias}?" : Alias;
        public bool IsNullable => Type != typeof(string) && Type != typeof(byte[]) && Type != typeof(object);
        public bool IsReferenceType { get; private set; }


        public TypeModel(Type type, string alias)
        {
            Type = type;
            Name = type == typeof(byte[]) ? "ByteArray" : type.Name;
            Alias = alias; // type == typeof(string) || type == typeof(byte[]) || type == typeof(object) ? $"{alias}?" : alias;
            IsReferenceType = type == typeof(string) || type == typeof(byte[]) || type == typeof(object);
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
            if (obj1 is null) return false;
            if (obj2 is null) return false;
            return obj1.Type == obj2.Type;
        }

        public static bool operator !=(TypeModel obj1, TypeModel obj2)
            => !(obj1 == obj2);

        public bool Equals(TypeModel? obj)
            => obj is not null && Type == obj.Type;

        public override bool Equals(object? obj)
            => obj is TypeModel t && Equals(t);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
