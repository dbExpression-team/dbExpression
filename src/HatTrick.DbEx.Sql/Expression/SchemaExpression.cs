using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class SchemaExpression : IAssemblyPart, IEquatable<SchemaExpression>
    {
        public string SchemaName { get; set; }
        public virtual string ConnectionName { get; set; }

        public SchemaExpression(string schemaName, string connectionName)
        {
            SchemaName = schemaName;
            ConnectionName = connectionName;
        }

        public override string ToString() => ToString("[s]");

        public string ToString(string format)
        {
            string val = null;
            switch (format)
            {
                case "s":
                    val = this.SchemaName;
                    break;
                case "[s]":
                    val = $"[{this.SchemaName}]";
                    break;
                default:
                    throw new ArgumentException("encountered unknown format string");
            }

            return val;
        }

        public bool Equals(SchemaExpression obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (string.Compare(obj.SchemaName, this.SchemaName, true) != 0) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SchemaExpression other)) return false;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (string.Compare(other.SchemaName, this.SchemaName, true) != 0) return false;

            return true;
        }

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(SchemaExpression obj1, SchemaExpression obj2)
        {
            if (ReferenceEquals(obj1, obj2)) return true;
            if (ReferenceEquals(obj1, null)) return false;
            if (ReferenceEquals(obj2, null)) return false;
            if (string.Compare(obj1.SchemaName, obj2.SchemaName, true) != 0) return false;

            return true;
        }

        public static bool operator !=(SchemaExpression obj1, SchemaExpression obj2)
            => !(obj1 == obj2);
    }
}
