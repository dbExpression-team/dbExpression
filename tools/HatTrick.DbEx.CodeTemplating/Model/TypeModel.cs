using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HatTrick.DbEx.CodeTemplating.Model
{
    public class TypeModel : IEquatable<TypeModel>
    {
        private Type type;

        public string Name { get; private set; }
        public string Alias { get; private set; }

        public bool IsNullable { get => type != typeof(string); }


        public TypeModel(Type type, string alias)
        {
            this.type = type;
            Name = type.Name;
            Alias = alias;
        }

        public TypeModel(Type type, string name, string alias)
        {
            this.type = type;
            Name = name;
            Alias = alias;
        }

        public override string ToString()
        {
            return type.Name;
        }

        #region equals
        public static bool operator ==(TypeModel obj1, TypeModel obj2)
        {
            if (ReferenceEquals(obj1, obj2)) return true;
            if (ReferenceEquals(obj1, null)) return false;
            if (ReferenceEquals(obj2, null)) return false;
            return obj1.type == obj2.type;
        }

        public static bool operator !=(TypeModel obj1, TypeModel obj2)
            => !(obj1 == obj2);

        public bool Equals(TypeModel obj)
            => obj is TypeModel t && type == t.type;

        public override bool Equals(object obj)
            => obj is TypeModel t && type == t.type;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }

    public class TypeModel<T> : TypeModel
    {
        public TypeModel(string alias)
            : base(typeof(T), alias)
        {
        }
    }
}
